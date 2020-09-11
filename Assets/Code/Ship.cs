using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public GameObject Part;
    public float MarshPower = 10;
    public float FrontForse = 1;
    GameObject _Ship;
    Rigidbody2D body;
    GameObject _ShuntingGreen;
    GameObject _ShuntingBlue;
    GameObject _ShuntingYellow;
    GameObject _ShuntingPink;
    GameObject _ShuntingDarkPink;
    GameObject _ShuntingSee;
    Vector3 ShuntigForce;
    Vector3 MarshForce;
    

    void Start()
    {
        _Ship = ShipStatus.Ship = transform.gameObject;
        _ShuntingGreen = ShipStatus.ShuntingGreen = transform.Find("Green").gameObject;
        _ShuntingBlue = ShipStatus.ShuntingBlue = transform.Find("Blue").gameObject;
        _ShuntingYellow = ShipStatus.ShuntingYellow = transform.Find("Yellow").gameObject;
        _ShuntingPink = ShipStatus.ShuntingPink = transform.Find("Pink").gameObject;
        _ShuntingDarkPink = ShipStatus.ShuntingDarkPink = transform.Find("DarkPink").gameObject;
        _ShuntingSee = ShipStatus.ShuntingSee = transform.Find("See").gameObject;
        ShipStatus.MarshScroll = GameObject.Find("MarshPowerControler");
        body = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (ShipStatus.Marsh1)
        {
            MarshForces("Marsh1");
            

        }
        if (ShipStatus.Marsh2)
        {
            MarshForces("Marsh2");
            
        }
        if (ShipStatus.Marsh3)
        {
            MarshForces("Marsh3");
            
        }
    }

    void Update()
    {
        if (Mathf.Abs(body.angularVelocity) < 2f && ShipStatus.AngSTB) body.angularVelocity = 0;

        if (ShipStatus.StartEction)
        {
            if (ShipStatus.ValueJoystickY == 0 && ShipStatus.ValueJoystickX < 0)
            {
                JoustickForces(_ShuntingPink);
                JoustickForces(_ShuntingDarkPink);
            }

            if (ShipStatus.ValueJoystickY == 0 && ShipStatus.ValueJoystickX > 0)
            {
                JoustickForces(_ShuntingYellow);
                JoustickForces(_ShuntingSee);
            }

            if (ShipStatus.ValueJoystickY > 0 && ShipStatus.ValueJoystickX == 0)
            {
                JoustickForces(_ShuntingGreen);
            }

            if (ShipStatus.ValueJoystickY < 0 && ShipStatus.ValueJoystickX == 0)
            {
                JoustickForces(_ShuntingBlue);
            }
            
        }
        else
        {
            
            if (ShipStatus.AngSTB)
            {
                if (ShipStatus.Ship.GetComponent<Rigidbody2D>().angularVelocity > 0)
                {
                    STBForces(_ShuntingYellow);
                    STBForces(_ShuntingSee);
                }

                if (ShipStatus.Ship.GetComponent<Rigidbody2D>().angularVelocity < 0)
                {
                    STBForces(_ShuntingPink);
                    STBForces(_ShuntingDarkPink);
                }
                
            }

            if (ShipStatus.VelSTB)
            {
                if (ShipStatus.Ship.GetComponent<Rigidbody2D>().velocity.magnitude > 0)
                {

                    ShipStatus.Ship.GetComponent<Rigidbody2D>().AddForce(-ShipStatus.Ship.GetComponent<Rigidbody2D>().velocity.normalized * MarshPower * SystemControler.TimeScaleConst * Time.deltaTime);
                    if (ShipStatus.Ship.GetComponent<Rigidbody2D>().velocity.magnitude > 0 && ShipStatus.Ship.GetComponent<Rigidbody2D>().velocity.magnitude < 5f) ShipStatus.Ship.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
            }
        }
    }

    

    private void LateUpdate()
    {
        
    }

    public void STBForces(GameObject Shunting)
    {
        ShuntigForce = -Shunting.transform.up * Mathf.Abs(FrontForse) * 10 * SystemControler.TimeScaleConst * Time.deltaTime;
        body.AddForceAtPosition(ShuntigForce, new Vector2(Shunting.transform.position.x, Shunting.transform.position.y));
        
    }

    public void JoustickForces(GameObject Shunting)
    {
        ShuntigForce = -Shunting.transform.up * Mathf.Abs(FrontForse) * SystemControler.TimeScaleConst * Time.deltaTime;
        body.AddForceAtPosition(-Shunting.transform.up * Mathf.Abs(ShipStatus.ValueJoystickX * FrontForse) * SystemControler.TimeScaleConst * Time.deltaTime, new Vector2(Shunting.transform.position.x, Shunting.transform.position.y));
        
    }

    public void MarshForces(string MarshName)
    {
        MarshForce = transform.up * ShipStatus.MarshScroll.GetComponent<Scrollbar>().value * MarshPower * Time.deltaTime;
        //body.AddForceAtPosition(MarshForce, new Vector2(transform.Find(MarshName).position.x, transform.Find(MarshName).position.y));
        body.AddForce(MarshForce);
        TrajectoryScript.Forces += MarshForce;
        
    }
}
