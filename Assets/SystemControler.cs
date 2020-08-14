using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemControler : MonoBehaviour
{
    public static List<GameObject> SystemObjects;
    public static GameObject Star;

    private void Awake()
    {
        Star = GameObject.Find("Star");
        SystemObjects = new List<GameObject>();

        GameObject[] System = GameObject.FindGameObjectsWithTag("Object");
        foreach (var Sys in System)
        {
            SystemObjects.Add(Sys);
            Sys.GetComponent<GravityForce>().SolDist = Vector2.Distance(Sys.transform.position, Star.transform.position);
        }
    }

    void Start()
    {
        
    }

}
