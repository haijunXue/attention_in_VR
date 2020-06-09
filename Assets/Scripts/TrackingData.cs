using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.XR;

public class TrackingData : MonoBehaviour
{
    void Awake()
    {
        var settings = new TobiiXR_Settings();
        TobiiXR.Start(settings);
    }
    

    // Update is called once per frame
    void Update()
    {
        // Get eye tracking data in world space
        var eyeTrackingData = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World);

        //Check if gaze ray is valid
        if(eyeTrackingData.GazeRay.IsValid)
        {
            // The origin of the gaze ray is a 3D point;
            var rayOrigin = eyeTrackingData.GazeRay.Origin;

            //The direction of the gaze ray is a normalized direction vector
            var rayDirection = eyeTrackingData.GazeRay.Direction;
            float timeStamp = eyeTrackingData.Timestamp;
            Debug.Log(timeStamp);
        }
    }
}
