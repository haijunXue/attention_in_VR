using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.XR;
using System.Text;
using System.IO;
using System.Globalization;
using System;


public class SaveData1 : MonoBehaviour
{
    // Start is called before the first frame update
    string filePath = @"C:\Users\LabBackpack1\Desktop\Haijun\Test\Data\";
    string delimiter = ",";

    string stream ;
    LineRenderer lineRenderer;
    GameObject indicator;
    public GameObject myPrefab;
    void Start()
    {
        var settings = new TobiiXR_Settings();
        TobiiXR.Start(settings);
       // StringBuilder builder = new StringBuilder();
        filePath = filePath + DateTime.Now.ToString("ss-mm-dd-MM-yyyy") + ".csv";
        //lineRenderer = gameObject.GetComponent<LineRenderer>();
        //indicator = GameObject.Find("Indicator");
    
    }
    
    
    // Update is called once per frame
    void Update()
    {
        var eyeTrackingData = TobiiXR.GetEyeTrackingData(TobiiXR_TrackingSpace.World);
        var csv = new StringBuilder();
        // Check if gaze ray is valid
        if(eyeTrackingData.GazeRay.IsValid)
        {
            
            // The origin of the gaze ray is a 3D point
            var rayOrigin = eyeTrackingData.GazeRay.Origin;
            var rayDirection = eyeTrackingData.GazeRay.Direction;
            //Debug.Log("rayOrigin" + "x: " + rayOrigin.x + "y: " + rayOrigin.y +"z:" + rayOrigin.z);
            //Debug.Log("rayDirection" + "x: " + rayDirection.x + "y: " + rayDirection.y +"z:" + rayDirection.z);

            RaycastHit hit;
            bool hitSomething = Physics.Raycast(rayOrigin, rayDirection, out hit, 100);
            if(hitSomething){
                Debug.Log("Position:"+hit.point);
                //indicator.transform.position = hit.point;

            }
            // The direction of the gaze ray is a normalized direction vector
            //var rayDirection = eyeTrackingData.GazeRay.Direction;
           // var X = rayOrigin.x;
            //var Y = rayOrigin.y;
            //var Z = rayOrigin.z;


            var Timestamp = eyeTrackingData.Timestamp;
            //bool Valid = eyeTrackingData.GazeRay.IsValid;

            //string csvRow  = string.Format("{0},{1},{2},{3},{4}", X.ToString(), Y.ToString(), Z.ToString(), Timestamp.ToString(),Valid.ToString());
            string csvRow  = string.Format("{0},{1},{2},{3}", hit.point.x.ToString(), hit.point.y.ToString(), hit.point.z.ToString(), Timestamp.ToString());
           
            //csv.AppendLine(csvRow);
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


            //var positions = new Vector3 [] {rayOrigin, rayOrigin + rayDirection * 100};
            

            //lineRenderer.SetPositions(positions);
            Instantiate(myPrefab, hit.point, Quaternion.identity);
          
        }

   
    }
}
