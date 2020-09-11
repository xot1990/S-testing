using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AtantionScript : MonoBehaviour
{
    public GameObject ship;
    public GameObject Grav;
    Text W;
    TrajectoryScript T;
    
    void Start()
    {
        W = GetComponent<Text>();
        T = ship.GetComponent<TrajectoryScript>();
    }

    
    void Update()
    {

        if(T.R > 500) W.text = "Before entering the gravity field \n" + (T.R - 500);
        if (T.R < 500) W.text = "Before leaving the gravity field \n " + (500 - T.R);
    }
}
