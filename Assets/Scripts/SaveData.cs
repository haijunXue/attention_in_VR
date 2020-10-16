using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.XR;
using System.Text;
using System.IO;
using System.Globalization;
using System;


public class SaveData : MonoBehaviour
{
    // Start is called before the first frame update
    string filePath = @"C:\Users\LabBackpack1\Desktop\Haijun\Test\Data\";

    void Start()
    {
        var settings = new TobiiXR_Settings();
        TobiiXR.Start(settings);
       // StringBuilder builder = new StringBuilder();
        filePath = filePath + DateTime.Now.ToString("ss-mm-dd-MM-yyyy") + ".csv";
        
    }
    
    
    // Update is called once per frame
    void Update()
    {
        var eyeTrackingData = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World);
       // var csv = new StringBuilder();
        // Check if gaze ray is valid
        if(eyeTrackingData.GazeRay.IsValid)
        {
            
            // The origin of the gaze ray is a 3D point
            var rayOrigin = eyeTrackingData.GazeRay.Origin;
            Debug.Log("rayOrigin" + rayOrigin.x + rayOrigin.y + rayOrigin.z);
            // The direction of the gaze ray is a normalized direction vector
            //var rayDirection = eyeTrackingData.GazeRay.Direction;
            var X = rayOrigin.x;
            var Y = rayOrigin.y;
            var Z = rayOrigin.z;
            var Timestamp = eyeTrackingData.Timestamp;
           

            string csvRow  = string.Format("{0},{1},{2},{3}", X.ToString(), Y.ToString(), Z.ToString(), Timestamp.ToString());
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(csvRow);

            if(!File.Exists(filePath))
                {
                    string str = string.Format("{0},{1},{2},{3}","X".ToString(),"Y".ToString(),"Z".ToString(),"TimeStamp".ToString());
                    File.WriteAllText(filePath, str);
                    File.WriteAllText(filePath, sb.ToString());
                }
                
            else
                File.AppendAllText(filePath, sb.ToString());
            //File.WriteAllText(filePath, sb.ToString());
        }

        
 
    }
}
