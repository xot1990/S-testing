using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlanet : MonoBehaviour
{
    GameObject Star;   
    Vector3 StarPos;
    Vector3 pos;


    float Xpos;
    float Ypos;

    float angle;
    float angle2;

    float a;
    float b;
    float c;
    float RandomAngle;


    void Start()
    {
        RandomAngle = Random.Range(10, 360);
        Star = GameObject.Find("Star");
        b = Vector3.Distance(Star.transform.position, transform.position);
        a = b * 0.6f;
        c = b;
        Xpos = Star.transform.position.x - Mathf.Cos(RandomAngle) * b;
        Ypos = Star.transform.position.y - Mathf.Sin(RandomAngle) * a;
        pos = new Vector3(Xpos, Ypos, 0);
        transform.position = pos;

    }

    
    void Update()
    {
        
        
        
    }

    private void FixedUpdate()
    {
        move();
    }

    public void move()
    {
        Vector3 Norm = new Vector3(-1, 0, 0);
        
        StarPos = Star.transform.position;

        RandomAngle = RandomAngle + Time.deltaTime / c;
        Xpos = Star.transform.position.x - Mathf.Cos(RandomAngle) * b ;
        Ypos = Star.transform.position.y - Mathf.Sin(RandomAngle) * a ;
        pos = new Vector3(Xpos,Ypos,0);
        Vector3 GO = new Vector3(StarPos.x - pos.x, StarPos.y - pos.y, StarPos.z - pos.z);
        GO.Normalize();
        angle = Vector2.SignedAngle(Norm,GO);        
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.position = pos;
        if (angle2 >= 360f) angle2 = 0;


        

    }
}
