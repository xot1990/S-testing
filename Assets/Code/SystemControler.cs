using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemControler : MonoBehaviour
{
    public static List<GameObject> SystemObjects;
    
    public static float TimeScaleConst = 1;
    public static float NowTimeScale = 1;
    public static float PastTimeScale = 1;
    public static bool TrajectoryOn;

    public static GameObject Ship;

    private void Awake()
    {
        
        SystemObjects = new List<GameObject>();

        GameObject[] System = GameObject.FindGameObjectsWithTag("Object");
        foreach (var Sys in System)
        {
            SystemObjects.Add(Sys);

        }
        Ship = GameObject.Find("MatherShip");

    }

    void Start()
    {
        
    }

    public static float GetFloat(string stringValue, float defaultValue)
    {
        float result = defaultValue;
        float.TryParse(stringValue, out result);
        return result;
    }
}
