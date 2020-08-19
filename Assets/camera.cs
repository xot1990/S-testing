using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject ship;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y, ship.transform.position.z - 10);
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            GetComponent<Camera>().orthographicSize += Input.GetAxis("Mouse ScrollWheel")*5;
            Debug.Log("done1");
        }
        else
        {
            GetComponent<Camera>().orthographicSize -= Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")*5);
            Debug.Log("done2");
        }
    }

    public void Scroll()
    {
        
    }
}
