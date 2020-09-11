using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject ship;
    public bool FreeCameraOn;
    public float panSpeed = 4.0f;

    private Vector3 mouseOrigin;
    private bool isPanning;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (!FreeCameraOn)
        {
            transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y, ship.transform.position.z - 10);
            if (Input.GetAxis("Mouse ScrollWheel") > 0) GetComponent<Camera>().orthographicSize += Input.GetAxis("Mouse ScrollWheel") * 5;
            else GetComponent<Camera>().orthographicSize -= Mathf.Abs(Input.GetAxis("Mouse ScrollWheel") * 5);
        }

        if (FreeCameraOn)
        {
            
            if (Input.GetMouseButtonDown(1))
            {
                mouseOrigin = Input.mousePosition;
                isPanning = true;
            }


            // cancel on button release
            if (!Input.GetMouseButton(1))
            {
                isPanning = false;
            }

            //move camera on X & Y
            if (isPanning)
            {
                Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
                
                // update x and y but not z
                Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);

                transform.Translate(move, Space.Self);
            }
        }
    }

    
}
