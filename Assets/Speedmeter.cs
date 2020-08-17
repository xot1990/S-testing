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
        StartCoroutine(Velocitymeter());
    }

    private void FixedUpdate()
    {
        
    }
    void Update()
    {
        
    }
    IEnumerator Velocitymeter()
    {
        while (true)
        {
            int i = 0;
            while (i < 10)
            {
                yield return new WaitForEndOfFrame();
                i++;
            }
            if (gameObject.name == "SpeedMeter")
            {
                Velocity = Ship.GetComponent<Rigidbody2D>().velocity.magnitude*SystemControler.TimeScaleConst * 1000;
                if (Velocity * 10000 > 600000)
                {
                    AngularVelosity = Ship.GetComponent<Rigidbody2D>().angularVelocity;
                    _velosity.text = "Velocity \n" + Mathf.Round((Velocity * 10000)*1000/3600) + "m/s";
                    _angularvelocity.text = "AngVelocity \n" + AngularVelosity;
                }
                else
                {
                    AngularVelosity = Ship.GetComponent<Rigidbody2D>().angularVelocity;
                    _velosity.text = "Velocity \n" + Mathf.Round(Velocity * 10000) + " Km/h";
                    _angularvelocity.text = "AngVelocity \n" + AngularVelosity;
                }
                if(Mathf.Round((Velocity * 10000) * 1000 / 3600) > 100000)
                {
                    AngularVelosity = Ship.GetComponent<Rigidbody2D>().angularVelocity;
                    _velosity.text = "Velocity \n" + Mathf.Round(((Velocity * 10000) * 1000 / 3600)/1000) + "Km/s";
                    _angularvelocity.text = "AngVelocity \n" + AngularVelosity;
                }
                
                
            }
            if (gameObject.name == "CSpeedMeter")
            {
                _velosity.text = "X Pull " + ShipStatus.ValueJoystickX;
                _angularvelocity.text = "Y Pull " + ShipStatus.ValueJoystickY;
            }
            i = 0;
        }
    }
}
