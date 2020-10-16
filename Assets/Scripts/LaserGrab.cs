using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserGrab : MonoBehaviour
{
    // Start is called before the first frame update
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean teleportAction;

    private Vector3 hitPoint;

    //connect the object
    private FixedJoint m_Joint = null;
    private Interactable m_CurrentInteractable = null;
    public List<Interactable> m_ContactInteractables = new List<Interactable>();

    void Start()
    {
        m_Joint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if(teleportAction.GetState(handType))
        {
            RaycastHit hit;
            if(Physics.Raycast(controllerPose.transform.position,transform.forward, out hit, 100))
            {
                PickUp(hit);
            }
            else
            {
                Drop();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
	{
		if(!other.gameObject.CompareTag("Interactable"))
			return;
		m_ContactInteractables.Add(other.gameObject.GetComponent<Interactable>());
	}

    private void OnTriggerExit(Collider other)
	{
		if(!other.gameObject.CompareTag("Interactable"))
			return;
		m_ContactInteractables.Remove(other.gameObject.GetComponent<Interactable>());
	}

   public void PickUp(RaycastHit hit)
	{
		m_CurrentInteractable = GetNearestInteractable();
		
		// Null check
		if(!m_CurrentInteractable)
			return;
	
		// Already held, check
		if(m_CurrentInteractable.m_ActiveHand)
			m_CurrentInteractable.m_ActiveHand.Drop();
		
		//Position
		m_CurrentInteractable.transform.position =  hit.point;

		//Attach
		Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
		m_Joint.connectedBody = targetBody;

		
	}

    	public void Drop()
	{
		//Null check
		if(!m_CurrentInteractable)
			return;
		
		// Apply velocity
		Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
		targetBody.velocity = controllerPose.GetVelocity();
		targetBody.angularVelocity = controllerPose.GetAngularVelocity();

		//Detach
		m_Joint.connectedBody = null;

		//Clear
		
		m_CurrentInteractable = null;
	}

	public Interactable GetNearestInteractable()
	{
		Interactable nearest = null;
		float minDistance = float.MaxValue;
		float distance = 0.0f;
		
		foreach(Interactable interactable in m_ContactInteractables)
		{
			distance = (interactable.transform.position-transform.position).sqrMagnitude;
			if(distance < minDistance)
			{
				minDistance = distance;
				nearest = interactable;
			}
		}
		
		return nearest;
	}
}
