using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Speedmeter : MonoBehaviour
{

    public GameObject Ship;
    public Text _velosity;
    public Text _angularvelocity;

    public float Velocity;
    public float AngularVelosity;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (gameObject.name == "SpeedMeter")
        {
            Velocity = Ship.GetComponent<Rigidbody2D>().velocity.magnitude;
            AngularVelosity = Ship.GetComponent<Rigidbody2D>().angularVelocity;
            _velosity.text = "Velocity \n" + Velocity;
            _angularvelocity.text = "AngVelocity \n" + AngularVelosity;
        }
        if (gameObject.name == "CSpeedMeter")
        {            
            _velosity.text = "X Pull " + ShipStatus.ValueJoystickX;
            _angularvelocity.text = "Y Pull " + ShipStatus.ValueJoystickY;
        }
    }
}
