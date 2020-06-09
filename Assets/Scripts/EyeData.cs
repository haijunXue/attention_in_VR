using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.XR;
using Tobii.Gaming;

public class EyeData : MonoBehaviour
{
    private static EyeData eyeData;
    //private static VerboseData verboseData;
    private float pupilDiameterLeft,pupilDiameterRight;
    private Vector2 pupilPositionLeft,pupilPositionRight;
    private float eyeOpenLeft, eyeOpenRight;

    void Awake()
    {
        var settings = new TobiiXR_Settings();
        TobiiXR.Start(settings);
    }
    void Update()
    {    
        /*
        HeadPose headPose = TobiiAPI.GetHeadPose();
        if (headPose.IsRecent())
        {
            print("HeadPose Position (X,Y,Z): " + headPose.Position.x + ", " + headPose.Position.y + ", " + headPose.Position.z);
            print("HeadPose Rotation (X,Y,Z): " + headPose.Rotation.eulerAngles.x + ", " + headPose.Rotation.eulerAngles.y + ", " + headPose.Rotation.eulerAngles.z);
        }

        */
        //SRanipal_Eye.GetEyeData(ref eyeData);
        //SRanipal_Eye.GetVerboseData(out verboseData);
        //pupil diameter    pupilDiameterLeft = eyeData.verbose_data.left.pupil_diameter_mm;
        //pupilDiameterRight = eyeData.verbose_data.right.pupil_diameter_mm; 
      //pupil positions    pupilPositionLeft = eyeData.verbose_data.left.pupil_position_in_sensor_area;
      //pupilPositionRight = eyeData.verbose_data.right.pupil_position_in_sensor_area;   
       //eye open    eyeOpenLeft = eyeData.verbose_data.left.eye_openness;   
       //eyeOpenRight = eyeData.verbose_data.right.eye_openness;
    }
}
