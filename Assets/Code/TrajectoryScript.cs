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
    private Vector2 Ag = Vector2.zero;
    public Rigidbody2D GravityObj;
    Vector2 Pos1;
    Vector2 Pos2;
    public static Vector3 Forces;
    public static Vector3 GForces;

    

    void Start()
    {
        body = transform.GetComponent<Rigidbody2D>();
        Line = GetComponent<LineRenderer>();
        EstimatedTime = 50;
        Line.positionCount = EstimatedTime;
        
    }

    
    void Update()
    {
        



    }

    private void FixedUpdate()
    {
       
        A = Forces / body.mass;
        Ag = GForces / body.mass;
        Forces = Vector2.zero;

    }

    

    public void Trajectory()
    {
        Vector3[] Points = new Vector3[EstimatedTime];
        float h = 0;
        
        for (int i = 0; EstimatedTime > i; i++)
        {
            h += 0.1f;

            Vector2 Velocity = body.velocity;
            Vector2 V = body.position + Velocity * h + (A * Mathf.Pow(h, 2) / 2);



            /*float angle = Vector2.Dot(Velocity, body.transform.up);            
            float x1 = A.x * Mathf.Cos((angle) * Time.deltaTime) - A.y * Mathf.Sin((angle) * Time.deltaTime);
            float y1 = A.y * Mathf.Cos((angle) * Time.deltaTime) + A.x * Mathf.Sin((angle) * Time.deltaTime);*/
            Velocity += A * h;

            Points[i] = new Vector3(V.x,V.y,0);

            
        }
        Line.SetPositions(Points);
    }

    float angle(Vector2 a,Vector2 b)
    {
        float _angle = Vector2.Angle(a, b);
        if (_angle > 90) _angle -= 90;
        return _angle;
    }

    Vector2 V(float t, float h)
    {
        float n = t / h;
        Vector2 sum = new Vector2();

        for(int i = 1; n >= i; i++ )
        {
            sum += A;
        }
        
        return body.velocity + h * sum;
    }

    Vector2 X(float t, float h)
    {
        Vector2 sum = new Vector2();
        float n = t / h;
        
        for(int i = 1; n >= i; i++)
        {
            sum += V((0 + (i-1)*h) + h/2, h);
        }

        return body.position + h * sum;
    }

    public void test()
    {
        Vector3[] Points = new Vector3[EstimatedTime];

        float h = Time.fixedDeltaTime;
        




        float _angle = angle(body.velocity, A);

        Vector2 G = new Vector2(Mathf.Cos(_angle), Mathf.Sin(_angle));

        for (int i = 0; EstimatedTime > i; i++)
        {
            
            Vector2 Coords = X(i, h);
            

            Points[i] = new Vector3(Coords.x, Coords.y, 0);

        }
        Line.SetPositions(Points);
    }

}
