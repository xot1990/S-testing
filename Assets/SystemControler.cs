using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemControler : MonoBehaviour
{
    public static List<GameObject> SystemObjects;
    public static GameObject Star;
    public static float TimeScaleConst = 0.001f;
    public static float NowTimeScale = 1;
    public static float PastTimeScale = 1;
    

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
