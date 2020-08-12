using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine;

public class CrestScript : MonoBehaviour
{

    Vector3 ZeroPos;
    public RectTransform CrestPos;
    
    
    public void CrestMove()
    {
        ShipStatus.StartEction = true;
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ZeroPos = CrestPos.GetComponent<RectTransform>().position;

        Vector3 Min = Camera.main.ScreenToWorldPoint(new Vector3(CrestPos.rect.xMin, CrestPos.rect.yMin, 0));
        Vector3 Max = Camera.main.ScreenToWorldPoint(new Vector3(CrestPos.rect.xMax, CrestPos.rect.yMax, 0));

        float deltaX = Max.x - Min.x;
        float deltaY = Max.y - Min.y;

        float X = Mathf.Clamp(MousePos.x, ZeroPos.x - deltaX / 2, ZeroPos.x + deltaX / 2);
        float Y = Mathf.Clamp(MousePos.y, ZeroPos.y - deltaY / 2, ZeroPos.y + deltaY / 2);

        if (ShipStatus.MoveX)
        {            
            transform.position = new Vector2(X, ZeroPos.y);
            ShipStatus.ValueJoystickX = (float)Math.Round((transform.position.x - ZeroPos.x) * 2.801f, 2);
        }

        if (ShipStatus.MoveY)
        {
            
            transform.position = new Vector2(ZeroPos.x, Y);
            ShipStatus.ValueJoystickY = (float)Math.Round((transform.position.y - ZeroPos.y) * 2.801f, 2);
        }
     
    }

    public void DestDrag()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ZeroPos = CrestPos.GetComponent<RectTransform>().position;

        Vector3 Min = Camera.main.ScreenToWorldPoint(new Vector3(CrestPos.rect.xMin, CrestPos.rect.yMin, 0));
        Vector3 Max = Camera.main.ScreenToWorldPoint(new Vector3(CrestPos.rect.xMax, CrestPos.rect.yMax, 0));

        float deltaX = Max.x - Min.x;
        float deltaY = Max.y - Min.y;

        float X = Mathf.Clamp(MousePos.x, ZeroPos.x - deltaX / 2, ZeroPos.x + deltaX / 2);
        float Y = Mathf.Clamp(MousePos.y, ZeroPos.y - deltaY / 2, ZeroPos.y + deltaY / 2);

        if (Mathf.Abs(Mathf.Abs(ZeroPos.x) - Mathf.Abs(X)) >= Mathf.Abs(Mathf.Abs(ZeroPos.y) - Mathf.Abs(Y)))
        {
            ShipStatus.MoveX = true;
        }
        if (Mathf.Abs(Mathf.Abs(ZeroPos.x) - Mathf.Abs(X)) <= Mathf.Abs(Mathf.Abs(ZeroPos.y) - Mathf.Abs(Y)))
        {
            ShipStatus.MoveY = true;

        }
    }

    public void BackOnCenter()
    {
        
        ZeroPos = CrestPos.GetComponent<RectTransform>().position;
        transform.position = ZeroPos;
        ShipStatus.ValueJoystickX = 0;
        ShipStatus.ValueJoystickY = 0;
        ShipStatus.StartEction = false;
        ShipStatus.MoveX = false;
        ShipStatus.MoveY = false;


    }

    
}
