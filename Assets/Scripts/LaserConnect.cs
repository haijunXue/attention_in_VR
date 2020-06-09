using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserConnect : MonoBehaviour
{
    public Transform CurrentTransfrom;
    public float length = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PickUpObj()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position,transform.forward,out hit,10.0f))
            {
                if(hit.transform.tag == "")
                {
                    SetNewTransform(hit.transform);
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {

        }
    }

    public void SetNewTransform(Transform newTransform)
    {
        if(CurrentTransfrom)
            return;
        
        CurrentTransfrom = newTransform;
        length = Vector3.Distance(transform.position,newTransform.position);
        
    }
}
