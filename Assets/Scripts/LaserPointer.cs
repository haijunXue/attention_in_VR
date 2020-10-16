using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class LaserPointer : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean teleportAction;


    public GameObject laserPrefab; // 1
    private GameObject laser; // 2
    private Transform laserTransform; // 3
    private Vector3 hitPoint; // 4


    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true);
        laserTransform.position = Vector3.Lerp(controllerPose.transform.position,hitPoint,0.5f);
       // laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x,
        laserTransform.localScale.y,hit.distance);
    }
    // Start is called before the first frame update
    void Start()
    {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 1
        if (teleportAction.GetState(handType))
        {
            RaycastHit hit;

            // 2
            if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100))
            {
                hitPoint = hit.point;
                ShowLaser(hit);
            }
        }
        else // 3
        {
            laser.SetActive(false);
        }

    }
}
