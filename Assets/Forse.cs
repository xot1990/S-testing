using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Forse : MonoBehaviour
{

    public GameObject Ship;
    public float Value;
    public InputField Field;
    public GameObject Canvas;
    public GameObject Part;

    private void Start()
    {
        Canvas = transform.parent.gameObject;
    }
    private float GetFloat(string stringValue, float defaultValue)
    {
        float result = defaultValue;
        float.TryParse(stringValue, out result);
        return result;
    }
    public void SetValue()
    {
        Value = GetFloat(Field.text, Value);
        Value = Mathf.Clamp(Value, 0, 10f);
        Field.text = "" + Value;
    }

    public void Forses()
    {
        
        
        switch (gameObject.name)
        {
            case "Green":
                {
                    Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(-Ship.transform.right * Value, new Vector2(Ship.transform.Find("Green").position.x, Ship.transform.Find("Green").position.y));
                    ArrowScript.angle = Vector2.SignedAngle(transform.up, Ship.GetComponent<Rigidbody2D>().velocity);
                    GameObject par = Instantiate(Part, Ship.transform.Find("Green").position, Quaternion.Euler(90, 90, 90));
                    par.transform.parent = Ship.transform;
                }
                break;
            case "Blue":
                {
                    Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(Ship.transform.right * Value, new Vector2(Ship.transform.Find("Blue").position.x, Ship.transform.Find("Blue").position.y));
                    ArrowScript.angle = Vector2.SignedAngle(transform.up, Ship.GetComponent<Rigidbody2D>().velocity);
                    GameObject par = Instantiate(Part, Ship.transform.Find("Blue").position, Quaternion.Euler(-90, 90, 90));
                    par.transform.parent = Ship.transform;
                }
                break;
            case "Yellow":
                {
                    Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(Ship.transform.right * Value, new Vector2(Ship.transform.Find("Yellow").position.x, Ship.transform.Find("Yellow").position.y));
                    ArrowScript.angle = Vector2.SignedAngle(transform.up, Ship.GetComponent<Rigidbody2D>().velocity);
                    GameObject par = Instantiate(Part, Ship.transform.Find("Yellow").position, Quaternion.Euler(180, 90, 90));
                    par.transform.parent = Ship.transform;
                }
                break;
            case "Pink":
                {
                    Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(-Ship.transform.right * Value, new Vector2(Ship.transform.Find("Pink").position.x, Ship.transform.Find("Pink").position.y));
                    ArrowScript.angle = Vector2.SignedAngle(transform.up, Ship.GetComponent<Rigidbody2D>().velocity);
                    GameObject par = Instantiate(Part, Ship.transform.Find("Pink").position, Quaternion.Euler(180, 90, 90));
                    par.transform.parent = Ship.transform;
                }
                break;
            case "DarkPink":
                {
                    Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(Ship.transform.right * Value, new Vector2(Ship.transform.Find("DarkPink").position.x, Ship.transform.Find("DarkPink").position.y));
                    ArrowScript.angle = Vector2.SignedAngle(transform.up, Ship.GetComponent<Rigidbody2D>().velocity);
                    GameObject par = Instantiate(Part, Ship.transform.Find("DarkPink").position, Quaternion.Euler(-180, 90, 90));
                    par.transform.parent = Ship.transform;
                }
                break;
            case "See":
                {
                    Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(-Ship.transform.right * Value, new Vector2(Ship.transform.Find("See").position.x, Ship.transform.Find("See").position.y));
                    ArrowScript.angle = Vector2.SignedAngle(transform.up, Ship.GetComponent<Rigidbody2D>().velocity);
                    GameObject par = Instantiate(Part, Ship.transform.Find("See").position, Quaternion.Euler(-180, 90, 90));
                    par.transform.parent = Ship.transform;
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
                        Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(-Ship.transform.right * 100, new Vector2(Ship.transform.Find("Marsh1").position.x, Ship.transform.Find("Marsh1").position.y));
                        GameObject par = Instantiate(Part, Ship.transform.Find("Marsh1").position, Quaternion.Euler(90, 90, 90));
                        par.transform.parent = Ship.transform;
                    }
                    if (ShipStatus.Marsh2)
                    {
                        Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(-Ship.transform.right * 100, new Vector2(Ship.transform.Find("Marsh2").position.x, Ship.transform.Find("Marsh2").position.y));
                        GameObject par = Instantiate(Part, Ship.transform.Find("Marsh2").position, Quaternion.Euler(90, 90, 90));
                        par.transform.parent = Ship.transform;
                    }
                    if (ShipStatus.Marsh3)
                    {
                        Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(-Ship.transform.right * 100, new Vector2(Ship.transform.Find("Marsh3").position.x, Ship.transform.Find("Marsh3").position.y));
                        GameObject par = Instantiate(Part, Ship.transform.Find("Marsh3").position, Quaternion.Euler(90, 90, 90));
                        par.transform.parent = Ship.transform;
                    }
                    ArrowScript.angle = Vector2.SignedAngle(transform.up, Ship.GetComponent<Rigidbody2D>().velocity);
                }
                break;

        }

        
        
    }
    public void FrontForses()
    {
        Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(transform.right * 100, new Vector2(Ship.transform.position.x - 0.129f, Ship.transform.position.y - 0.482f));
    }

    public void FindAllForses()
    {
        float _Value;
        for (int i = 0; Ship.transform.childCount > i; i++)
        {
            
            switch (Ship.transform.GetChild(i).name)
            {
                
                case "Green":
                    {
                        _Value = GetFloat(Canvas.transform.Find("Green").GetComponentInChildren<InputField>().text, Value);
                        if (_Value != 0)
                        {
                            Debug.Log("done");
                            Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(-Ship.transform.right * _Value, new Vector2(Ship.transform.Find("Green").position.x, Ship.transform.Find("Green").position.y));
                        }
                    }
                    break;
                case "Blue":
                    {
                        _Value = GetFloat(Canvas.transform.Find("Blue").GetComponentInChildren<InputField>().text, Value);
                        if (_Value != 0)
                        {
                            Debug.Log("done");
                            Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(Ship.transform.right * _Value, new Vector2(Ship.transform.Find("Blue").position.x, Ship.transform.Find("Blue").position.y));
                        }
                    }
                    break;
                case "Yellow":
                    {
                        _Value = GetFloat(Canvas.transform.Find("Yellow").GetComponentInChildren<InputField>().text, Value);
                        if (_Value != 0)
                        {
                            Debug.Log("done");
                            Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(Ship.transform.right * _Value, new Vector2(Ship.transform.Find("Yellow").position.x, Ship.transform.Find("Yellow").position.y));
                        }
                    }
                    break;
                case "Pink":
                    {
                        _Value = GetFloat(Canvas.transform.Find("Pink").GetComponentInChildren<InputField>().text, Value);
                        if (_Value != 0)
                        {
                            Debug.Log("done");
                            Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(-Ship.transform.right * _Value, new Vector2(Ship.transform.Find("Pink").position.x, Ship.transform.Find("Pink").position.y));
                        }
                    }
                    break;
                case "DarkPink":
                    {
                        _Value = GetFloat(Canvas.transform.Find("DarkPink").GetComponentInChildren<InputField>().text, Value);
                        if (_Value != 0)
                        {
                            Debug.Log("done");
                            Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(Ship.transform.right * _Value, new Vector2(Ship.transform.Find("DarkPink").position.x, Ship.transform.Find("DarkPink").position.y));
                        }
                    }
                    break;
                case "See":
                    {
                        _Value = GetFloat(Canvas.transform.Find("See").GetComponentInChildren<InputField>().text, Value);
                        if (_Value != 0)
                        {
                            Debug.Log("done");
                            Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(-Ship.transform.right * _Value, new Vector2(Ship.transform.Find("See").position.x, Ship.transform.Find("See").position.y));
                        }
                    }
                    break;
                    
            }
        }
    }
}
