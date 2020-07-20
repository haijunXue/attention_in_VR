using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.XR;
using System.Text;
using System.IO;
using System.Globalization;
using System;


public class SaveData2 : MonoBehaviour
{
    // Start is called before the first frame update

    string filePath = @"C:\Users\LabBackpack1\Desktop\Haijun\Test\Data\";
    void Start()
    {
        //start tobiixr.
        var settings = new TobiiXR_Settings();
        TobiiXR.Start(settings);
       
        filePath = filePath + DateTime.Now.ToString("ss-mm-dd-MM-yyyy") + ".csv";
    }

    // Update is called once per frame
    void Update()
    {
        var eyeTrackingData = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World);
        StringBuilder sb = new StringBuilder();
        if(eyeTrackingData.GazeRay.IsValid)
        {
            // The origin of the gaze ray is a 3D point
            var rayOrigin = eyeTrackingData.GazeRay.Origin;
            // The direction of the gaze ray 
            var rayDirection = eyeTrackingData.GazeRay.Direction;

            RaycastHit hit;
            bool hitSomething = Physics.Raycast(rayOrigin, rayDirection, out hit, 100);
            if(hitSomething){
                Debug.Log("Position:"+hit.point);
                //indicator.transform.position = hit.point;
                var Timestamp = eyeTrackingData.Timestamp;
                string csvRow  = string.Format("{0},{1},{2},{3}", hit.point.x.ToString(), hit.point.y.ToString(), hit.point.z.ToString(), Timestamp.ToString());

                
                sb.AppendLine(csvRow);
            }
        }

        if(!File.Exists(filePath))
            {
               
                File.WriteAllText(filePath, sb.ToString());
            }
                
            else
                File.AppendAllText(filePath, sb.ToString());

        
    }
}
