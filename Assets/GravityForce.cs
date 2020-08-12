using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForce : MonoBehaviour
{
    public float mass;
    public float GravityConst;

    void Start()
    {
        GravityConst = 6.67430f * Mathf.Pow(10, -11);
    }

    
    void Update()
    {
        foreach(var Obj in SystemControler.SystemObjects)
        {
            float dist = Vector3.Distance(transform.position, Obj.transform.position);
            Vector2 dest = Obj.transform.position - transform.position;
            Vector2 d = new Vector2(0, 1);
            dest.Normalize();
            Vector2 forse = d * GravityConst * ((mass * Obj.GetComponent<GravityForce>().mass) / dist*dist);
            Obj.GetComponent<Rigidbody2D>().AddForce(d);
        }
        
    }
}
