using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public GameObject Part;

    void Start()
    {
        ShipStatus.Ship = transform.gameObject;
        ShipStatus.ShuntingGreen = transform.Find("Green").gameObject;
        ShipStatus.ShuntingBlue = transform.Find("Blue").gameObject;
        ShipStatus.ShuntingYellow = transform.Find("Yellow").gameObject;
        ShipStatus.ShuntingPink = transform.Find("Pink").gameObject;
        ShipStatus.ShuntingDarkPink = transform.Find("DarkPink").gameObject;
        ShipStatus.ShuntingSee = transform.Find("See").gameObject;
    }

   
    void Update()
    {
        if (ShipStatus.StartEction)
        {
            if (ShipStatus.ValueJoystickY == 0 && ShipStatus.ValueJoystickX < 0)
            {
                
                ShipStatus.Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(-ShipStatus.Ship.transform.right * Mathf.Abs(ShipStatus.ValueJoystickX*ShipStatus.gravityconst) * Time.deltaTime, new Vector2(ShipStatus.ShuntingPink.transform.position.x, ShipStatus.ShuntingPink.transform.position.y));
                GameObject par1 = Instantiate(Part, ShipStatus.Ship.transform.Find("Pink").position, Quaternion.Euler(180, 90, 90));
                par1.transform.parent = ShipStatus.Ship.transform;

                ShipStatus.Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(ShipStatus.Ship.transform.right * Mathf.Abs(ShipStatus.ValueJoystickX * ShipStatus.gravityconst) * Time.deltaTime, new Vector2(ShipStatus.ShuntingDarkPink.transform.position.x, ShipStatus.ShuntingDarkPink.transform.position.y));
                GameObject par2 = Instantiate(Part, ShipStatus.Ship.transform.Find("DarkPink").position, Quaternion.Euler(-180, 90, 90));
                par2.transform.parent = ShipStatus.Ship.transform;
            }

            if (ShipStatus.ValueJoystickY == 0 && ShipStatus.ValueJoystickX > 0)
            {

                ShipStatus.Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(ShipStatus.Ship.transform.right * Mathf.Abs(ShipStatus.ValueJoystickX * ShipStatus.gravityconst) * Time.deltaTime, new Vector2(ShipStatus.ShuntingYellow.transform.position.x, ShipStatus.ShuntingYellow.transform.position.y));
                GameObject par1 = Instantiate(Part, ShipStatus.Ship.transform.Find("Yellow").position, Quaternion.Euler(180, 90, 90));
                par1.transform.parent = ShipStatus.Ship.transform;

                ShipStatus.Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(-ShipStatus.Ship.transform.right * Mathf.Abs(ShipStatus.ValueJoystickX * ShipStatus.gravityconst) * Time.deltaTime, new Vector2(ShipStatus.ShuntingSee.transform.position.x, ShipStatus.ShuntingSee.transform.position.y));
                GameObject par2 = Instantiate(Part, ShipStatus.Ship.transform.Find("See").position, Quaternion.Euler(-180, 90, 90));
                par2.transform.parent = ShipStatus.Ship.transform;
            }

            if (ShipStatus.ValueJoystickY > 0 && ShipStatus.ValueJoystickX == 0)
            {
                ShipStatus.Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(-ShipStatus.Ship.transform.right * Mathf.Abs(ShipStatus.ValueJoystickY * ShipStatus.gravityconst*SystemControler.TimeScaleConst), new Vector2(ShipStatus.ShuntingGreen.transform.position.x, ShipStatus.ShuntingGreen.transform.position.y));                
                GameObject par = Instantiate(Part, ShipStatus.Ship.transform.Find("Green").position, Quaternion.Euler(90, 90, 90));
                par.transform.parent = ShipStatus.Ship.transform;
            }

            if (ShipStatus.ValueJoystickY < 0 && ShipStatus.ValueJoystickX == 0)
            {
                ShipStatus.Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(ShipStatus.Ship.transform.right * Mathf.Abs(ShipStatus.ValueJoystickY * ShipStatus.gravityconst* SystemControler.TimeScaleConst), new Vector2(ShipStatus.ShuntingBlue.transform.position.x, ShipStatus.ShuntingBlue.transform.position.y));
                GameObject par = Instantiate(Part, ShipStatus.Ship.transform.Find("Blue").position, Quaternion.Euler(90, 90, 90));
                par.transform.parent = ShipStatus.Ship.transform;
            }
        }
        else
        {
            if (ShipStatus.AngSTB)
            {
                if (ShipStatus.Ship.GetComponent<Rigidbody2D>().angularVelocity > 0)
                {
                    ShipStatus.Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(ShipStatus.Ship.transform.right * Mathf.Abs(10 * ShipStatus.gravityconst) * Time.deltaTime, new Vector2(ShipStatus.ShuntingYellow.transform.position.x, ShipStatus.ShuntingYellow.transform.position.y));
                    GameObject par1 = Instantiate(Part, ShipStatus.Ship.transform.Find("Yellow").position, Quaternion.Euler(180, 90, 90));
                    par1.transform.parent = ShipStatus.Ship.transform;

                    ShipStatus.Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(-ShipStatus.Ship.transform.right * Mathf.Abs(10 * ShipStatus.gravityconst) * Time.deltaTime, new Vector2(ShipStatus.ShuntingSee.transform.position.x, ShipStatus.ShuntingSee.transform.position.y));
                    GameObject par2 = Instantiate(Part, ShipStatus.Ship.transform.Find("See").position, Quaternion.Euler(-180, 90, 90));
                    par2.transform.parent = ShipStatus.Ship.transform;
                }

                if (ShipStatus.Ship.GetComponent<Rigidbody2D>().angularVelocity < 0)
                {
                    ShipStatus.Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(-ShipStatus.Ship.transform.right * Mathf.Abs(10 * ShipStatus.gravityconst) * Time.deltaTime, new Vector2(ShipStatus.ShuntingPink.transform.position.x, ShipStatus.ShuntingPink.transform.position.y));
                    GameObject par1 = Instantiate(Part, ShipStatus.Ship.transform.Find("Pink").position, Quaternion.Euler(180, 90, 90));
                    par1.transform.parent = ShipStatus.Ship.transform;

                    ShipStatus.Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(ShipStatus.Ship.transform.right * Mathf.Abs(10 * ShipStatus.gravityconst) * Time.deltaTime, new Vector2(ShipStatus.ShuntingDarkPink.transform.position.x, ShipStatus.ShuntingDarkPink.transform.position.y));
                    GameObject par2 = Instantiate(Part, ShipStatus.Ship.transform.Find("DarkPink").position, Quaternion.Euler(-180, 90, 90));
                    par2.transform.parent = ShipStatus.Ship.transform;
                }
               
            }

            if (ShipStatus.VelSTB)
            {
                if (ShipStatus.Ship.GetComponent<Rigidbody2D>().velocity.magnitude > 0)
                {

                    ShipStatus.Ship.GetComponent<Rigidbody2D>().AddForce(-ShipStatus.Ship.GetComponent<Rigidbody2D>().velocity.normalized * 5 * ShipStatus.gravityconst * SystemControler.TimeScaleConst);
                    if (ShipStatus.Ship.GetComponent<Rigidbody2D>().velocity.magnitude * 1000000 > 0 && ShipStatus.Ship.GetComponent<Rigidbody2D>().velocity.magnitude*1000000 < 0.1f) ShipStatus.Ship.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
            }
        }
    }
}
