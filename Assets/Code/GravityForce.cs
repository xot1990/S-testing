using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForce : MonoBehaviour
{
    
    float GravityConst = 1f;
    Rigidbody2D body;
    public float dist;   
   

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
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
                
                Vector2 dest = Obj.transform.position - transform.position;
                Vector2 d = new Vector2(0, 1);
                dest.Normalize();
                dist = Vector3.Distance(Obj.transform.position, transform.position);
                Vector3 forse = dest * GravityConst * ((body.mass * Obj.GetComponent<Rigidbody2D>().mass) / Mathf.Pow(dist, 2));
                if (dist > 15)
                {
                    Obj.GetComponent<Rigidbody2D>().AddForce(-forse * SystemControler.TimeScaleConst);
                    
                    TrajectoryScript.GForces += -forse;
                    
                }
                /*if (gameObject.name == "Юпитер" && Obj.name == "MatherShip")
                {
                    Debug.Log(dist);
                    Debug.Log(forse.magnitude);
                }*/


            }
        }
    }
}
