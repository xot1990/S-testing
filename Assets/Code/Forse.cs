using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Forse : MonoBehaviour
{

    public GameObject Ship;
    Rigidbody2D body;
    public float Value;
    InputField Field;
    public GameObject Canvas;
    public GameObject Part;    
    float _Value;
    Vector2 EnginePos;
    Ship _Ship;

    private void Awake()
    {
        body = Ship.GetComponent<Rigidbody2D>();
        _Ship = Ship.GetComponent<Ship>();
    }

    private void Start()
    {
        Canvas = transform.parent.gameObject;
    }

    public void Forses()
    {
        switch (gameObject.name)
        {
            case "Green":
                {
                    FrontForcesForManualControl(ShipStatus.ShuntingGreen);
                }
                break;
            case "Blue":
                {
                    FrontForcesForManualControl(ShipStatus.ShuntingBlue);
                }
                break;
            case "Yellow":
                {
                    FrontForcesForManualControl(ShipStatus.ShuntingYellow);
                }
                break;
            case "Pink":
                {
                    FrontForcesForManualControl(ShipStatus.ShuntingPink);
                }
                break;
            case "DarkPink":
                {
                    FrontForcesForManualControl(ShipStatus.ShuntingDarkPink);
                }
                break;
            case "See":
                {
                    FrontForcesForManualControl(ShipStatus.ShuntingSee);
                }
                break;

            case "Grey":
                {
                    FindAllForses();
                    ArrowScript.angle = Vector2.SignedAngle(transform.up, Ship.GetComponent<Rigidbody2D>().velocity);
                }
                break;
            case "Marsh":
                {
                    if (ShipStatus.Marsh1)
                    {
                        MarshPower("Marsh1");
                    }
                    if (ShipStatus.Marsh2)
                    {
                        MarshPower("Marsh2");
                    }
                    if (ShipStatus.Marsh3)
                    {
                        MarshPower("Marsh3");
                    }
                    ArrowScript.angle = Vector2.SignedAngle(transform.up, Ship.GetComponent<Rigidbody2D>().velocity);
                }
                break;
        }
        
    }

    public void FrontForcesForManualControl(GameObject Shunting)
    {
        
        EnginePos = new Vector2(Shunting.transform.position.x, Shunting.transform.position.y);
        body.AddForceAtPosition(Shunting.transform.up * Value, EnginePos);
        ArrowScript.angle = Vector2.SignedAngle(transform.up, Ship.GetComponent<Rigidbody2D>().velocity);     
    }

    public void MarshPower(string MarshName)
    {
        body.AddForceAtPosition(-Ship.transform.right * ShipStatus.MarshScroll.GetComponent<Scrollbar>().value * _Ship.MarshPower * Time.deltaTime, new Vector2(Ship.transform.Find(MarshName).position.x, Ship.transform.Find(MarshName).position.y));               
    }

   

    public void FindAllForses()
    {
        
        for (int i = 0; Ship.transform.childCount > i; i++)
        {
            FrontForceForGreyButton(Ship.transform.GetChild(i).name);            
        }
    }

    public void FrontForceForGreyButton(string Name)
    {
        _Value = SystemControler.GetFloat(Canvas.transform.Find(Name).GetComponentInChildren<InputField>().text, Value);
        if (_Value != 0)
        {
            Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(Ship.transform.right * _Value, new Vector2(Ship.transform.Find(Name).position.x, Ship.transform.Find(Name).position.y));
        }
    }
    
}
