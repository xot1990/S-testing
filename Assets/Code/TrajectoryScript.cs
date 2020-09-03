using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryScript : MonoBehaviour
{

    public bool SelfOn;
    Rigidbody2D body;
    LineRenderer Line;
    public int EstimatedTime;
    List<Vector3> Coords;
    Vector3[] Points;
    private Vector2 lastVelocity = Vector2.zero;
    private Vector2 A = Vector2.zero;
    public Rigidbody2D GravityObj;
    Vector2 Pos1;
    Vector2 Pos2;

    void Start()
    {
        body = transform.GetComponent<Rigidbody2D>();
        Line = GetComponent<LineRenderer>();
        EstimatedTime = 50;
        Line.positionCount = EstimatedTime;
        
    }

    
    void Update()
    {
        A = (body.velocity - lastVelocity) / Time.deltaTime;
        lastVelocity = body.velocity;


    }

    private void FixedUpdate()
    {
        
        
    }

    float a(float t)
    {
        return t * t / 2;
    }

    public void Trajectory()
    {
        Vector3[] Points = new Vector3[EstimatedTime];


        for (int i = 0; EstimatedTime > i; i++)
        {
            
            Vector2 V = body.position + body.velocity * i + (A * Mathf.Pow(i, 2) / 2);
            
            Points[i] = new Vector3(V.x,V.y,0);
            
        }
        Line.SetPositions(Points);
    }

    public void test()
    {
        Vector3[] Points = new Vector3[EstimatedTime];

        float[] x = new float[EstimatedTime];
        float[] y = new float[EstimatedTime];

        
        x[0] = body.position.x;
        x[1] = body.position.x * 0.0001f;
        y[0] = body.position.y;
        y[1] = body.position.x * 0.0001f;

        Points[0] = new Vector3(x[0], y[0], 0);

        for (int i = 1; EstimatedTime - 1 > i; i++)
        {
            x[i + 1] = 2 * x[i] - x[i - 1] * a(i);
            y[i + 1] = 2 * y[i] - y[i - 1] * a(i);

            Points[i] = new Vector3(x[i], y[i], 0);
            Debug.Log(x[i + 1]);
            Debug.Log(y[i + 1]);
        }
        Line.SetPositions(Points);
    }

}
