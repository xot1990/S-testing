using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationScript : MonoBehaviour
{
    public GameObject MatherObject;
    public Vector3 PlanetPos;
    public int StationId;
    public float RandomAngle;
    public float AngularVelocity = 4;
    public float Elongation;
    public float Flattening;

    void Start()
    {
        RandomAngle = Random.Range(10, 360);
        Elongation = 30f;
        Flattening = 30f;
    }

    
    void Update()
    {       
        move();        
    }

    public void move()
    {
        Vector3 Norm = new Vector3(-1, 0, 0);

        RandomAngle = RandomAngle + Time.deltaTime / AngularVelocity;
        float Xpos = MatherObject.transform.position.x - Mathf.Cos(RandomAngle) * Elongation;
        float Ypos = MatherObject.transform.position.y - Mathf.Sin(RandomAngle) * Flattening;
        Vector3 pos = new Vector3(Xpos, Ypos, 0);
        Vector3 GO = new Vector3(MatherObject.transform.position.x - pos.x, MatherObject.transform.position.y - pos.y, MatherObject.transform.position.z - pos.z);
        GO.Normalize();
        float angle = Vector2.SignedAngle(Norm, GO);
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.position = pos;

    }

}
