using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForce : MonoBehaviour
{
    
    float GravityConst = 0.277f;
    Rigidbody2D body;
    public Vector2 StartForce;
    public float forses;
    public Vector2 Forses;
    public float dist;
    float a;
    public float SolDist;

    void Start()
    {
        StartForce = new Vector2(0, 1);
        body = GetComponent<Rigidbody2D>();
        if (gameObject != SystemControler.Star) a = Mathf.Sqrt(GravityConst * SystemControler.Star.GetComponent<Rigidbody2D>().mass / SolDist)* GetComponent<Rigidbody2D>().mass;
        if (gameObject.name == "MatherShip") a = 0;
        Debug.Log(a);
        body.AddForce(StartForce*a,ForceMode2D.Impulse);
    }

    
    void Update()
    {
        
        
    }
    private void FixedUpdate()
    {
        foreach (var Obj in SystemControler.SystemObjects)
        {
            if (gameObject != Obj)
            {
                dist = Vector3.Distance(transform.position, Obj.transform.position);
                
                Vector2 dest = Obj.transform.position - transform.position;
                Vector2 d = new Vector2(0, 1);
                dest.Normalize();
                Vector2 forse = dest * GravityConst * ((body.mass * Obj.GetComponent<Rigidbody2D>().mass) / Mathf.Pow(dist,2));
                Obj.GetComponent<Rigidbody2D>().AddForce(-forse);
                forses = forse.magnitude;
                Forses = forse;
            }
        }
    }
}
