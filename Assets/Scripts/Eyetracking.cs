using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class Eyetracking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GazePoint gazePoint = TobiiAPI.GetGazePoint();
        if (gazePoint.IsRecent()) // Use IsValid property instead to process old but valid data
        {
            // Note: Values can be negative if the user looks outside the game view.
            print("Gaze point on Screen (X,Y): " + gazePoint.Screen.x + ", " + gazePoint.Screen.y);
        }
    }
}
