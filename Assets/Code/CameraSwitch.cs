using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject CamMain;
    
    public void Scroll()
    {
        if (gameObject.name.Contains("On"))
        {
            CamMain.GetComponent<camera>().FreeCameraOn = true;
            CamMain.GetComponent<Camera>().orthographicSize += 300;

            
        }
        if (gameObject.name.Contains("Off"))
        {
            CamMain.GetComponent<camera>().FreeCameraOn = false;
            CamMain.GetComponent<Camera>().orthographicSize -= 300;
        }
    }
}
