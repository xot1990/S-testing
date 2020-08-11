using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public GameObject Ship;
    public static float angle;
    void Start()
    {
        
    }

   
    void Update()
    {      
        
        transform.rotation = Quaternion.Euler(0,0, angle);
    }
}
