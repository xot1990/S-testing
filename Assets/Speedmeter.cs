using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Speedmeter : MonoBehaviour
{

    public GameObject Ship;
    public Text _velosity;
    public Text _angularvelocity;

    public float Velocity;
    public float AngularVelosity;

    void Start()
    {
        
    }

    
    void Update()
    {
        Velocity = Ship.GetComponent<Rigidbody2D>().velocity.magnitude;
        AngularVelosity = Ship.GetComponent<Rigidbody2D>().angularVelocity;
        _velosity.text = "Velocity "+Velocity;
        _angularvelocity.text = "AngVelocity"+AngularVelosity;
    }
}
