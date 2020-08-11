using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine;

public class CrestScript : MonoBehaviour
{

    Vector3 ZeroPos;
    public RectTransform CrestPos;
    
    

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void CrestMove()
    {
        ShipStatus.StartEction = true;
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = MousePos;
        ZeroPos = CrestPos.GetComponent<RectTransform>().position;
        Vector3 Min = Camera.main.ScreenToWorldPoint(new Vector3(CrestPos.rect.xMin, CrestPos.rect.yMin, 0));
        Vector3 Max = Camera.main.ScreenToWorldPoint(new Vector3(CrestPos.rect.xMax, CrestPos.rect.yMax, 0));
        float deltaX = Max.x - Min.x;
        float deltaY = Max.y - Min.y;

        float X = Mathf.Clamp(MousePos.x, ZeroPos.x - deltaX / 2, ZeroPos.x + deltaX / 2);
        float Y = Mathf.Clamp(MousePos.y, ZeroPos.y - deltaY / 2, ZeroPos.y + deltaY / 2);



        if (Mathf.Abs(transform.position.x - ZeroPos.x) > Mathf.Abs(transform.position.y - ZeroPos.y))
        {
            
            transform.position = new Vector2(X,ZeroPos.y);
            ShipStatus.ValueJoystickX = (float)Math.Round((transform.position.x - ZeroPos.x) * 2.801f, 2);
        }
        else
        {
            
            transform.position = new Vector2(ZeroPos.x,Y);
            ShipStatus.ValueJoystickY = (float)Math.Round((transform.position.y - ZeroPos.y) * 2.801f, 2);
        }


        
    }

    public void BackOnCenter()
    {
        Debug.Log("done");
        ZeroPos = CrestPos.GetComponent<RectTransform>().position;
        transform.position = ZeroPos;
        ShipStatus.ValueJoystickX = 0;
        ShipStatus.ValueJoystickY = 0;
        ShipStatus.StartEction = false;


        
    }

    public void ComputerControlForces()
    {
       
        /*
        ShipStatus.Ship.GetComponent<Rigidbody2D>().AddForceAtPosition(-ShipStatus.Ship.transform.right * Mathf.Abs(ShipStatus.ValueJoystickX), new Vector2(ShipStatus.ShuntingGreen.transform.position.x, ShipStatus.ShuntingGreen.transform.position.y));
        GameObject par = Instantiate(Part, ShipStatus.ShuntingGreen.transform.position, Quaternion.Euler(90, 90, 90));
        par.transform.parent = ShipStatus.Ship.transform;
        */
    }
}
