using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class FreeCameraScript : MonoBehaviour
{
    Camera cam;
    public GameObject dragW;
    
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        cam.transform.position = new Vector3(dragW.transform.position.x, dragW.transform.position.y,-10);
    }


}
