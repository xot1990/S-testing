using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForce : MonoBehaviour
{
    
    float GravityConst = 0.1f;
    Rigidbody2D body;
    public Vector2 StartForce;
    public float forses;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.AddForce(StartForce);
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
                float dist = Vector3.Distance(transform.position, Obj.transform.position);
                
                Vector2 dest = Obj.transform.position - transform.position;
                Vector2 d = new Vector2(0, 1);
                dest.Normalize();
                Vector2 forse = dest * GravityConst * ((body.mass * Obj.GetComponent<Rigidbody2D>().mass) / dist * dist);
                Obj.GetComponent<Rigidbody2D>().AddForce(-forse);
                forses = forse.magnitude;
            }
        }
    }
}
