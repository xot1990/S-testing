using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemControler : MonoBehaviour
{
    public static List<GameObject> SystemObjects;


    void Start()
    {
        SystemObjects = new List<GameObject>();
        GameObject[] System = GameObject.FindGameObjectsWithTag("Object");
        foreach (var Sys in System)
        {
            SystemObjects.Add(Sys);
        }
    }

}
