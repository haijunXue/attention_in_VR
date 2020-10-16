using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.XR;
using System.Text;
using System.IO;
using System.Globalization;
using System;


public class PositonRay : MonoBehaviour
{
   // Start is called before the first frame update

    LineRenderer lineRenderer;
    GameObject indicator;
    public GameObject myPrefab;
    void Start()
    {
        var settings = new TobiiXR_Settings();
        TobiiXR.Start(settings);
     
    }
    
    
    // Update is called once per frame
    void Update()
    {
        var eyeTrackingData = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World);
        var csv = new StringBuilder();
        // Check if gaze ray is valid
        if(eyeTrackingData.GazeRay.IsValid)
        {
            
          
            var rayOrigin = eyeTrackingData.GazeRay.Origin;
            var rayDirection = eyeTrackingData.GazeRay.Direction;
  
            RaycastHit hit;
            bool hitSomething = Physics.Raycast(rayOrigin, rayDirection, out hit, 100);
            if(hitSomething){
                Debug.Log("Position:"+hit.point);

            }

            //lineRenderer.SetPositions(positions);
            Instantiate(myPrefab, hit.point, Quaternion.identity);
          
        }

   
    }
}
