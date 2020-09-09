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
    public int iter;
    float M;
    Vector2[] Vsum;
    Vector2[] Asum;
    Vector2[] VGsum;

    Vector2 Kv1;
    Vector2 Kv2;
    Vector2 Kv3;
    Vector2 Kv4;
    Vector2 Kr1;
    Vector2 Kr2;
    Vector2 Kr3;
    Vector2 Kr4;
    Vector2 R;

    void Start()
    {
        body = transform.GetComponent<Rigidbody2D>();
        Line = GetComponent<LineRenderer>();
        EstimatedTime = 1000;
        Line.positionCount = EstimatedTime;
        M = 0.227f * GravityObj.mass;
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


            Points[i] = new Vector3(V.x,V.y,0);

            
        }
        Line.SetPositions(Points);
    }

    Vector2[] _Asum(float t, float h)
    {
        Vector2 sum = new Vector2();
        float n = t / h;
        int N = (int)Mathf.Round(n);
        
        Asum = new Vector2[N];

        for (int i = 0; N > i; i++)
        {
            iter++;
            sum += A;            
            Asum[i] = sum;
        }
        return Asum;
    }

    Vector2[] _Vsum(float t, float h)
    {
        Vector2 sum = new Vector2();
        float n = t / h;
        int N = (int)Mathf.Round(n);
        Vsum = new Vector2[N];

        for (int i = 0; N > i; i++)
        {
            iter++;
            sum += V((0 + (i - 1) * h) + h / 2, h);
            Vsum[i] = sum;
        }
       
        return Vsum;
    }

    Vector2[] _VGsum(float t, float h)
    {
        float n = t / h;
        int N = (int)Mathf.Round(n);
        VGsum = new Vector2[N];
        R =  (-GravityObj.transform.position + transform.position) * Vector2.Distance(GravityObj.transform.position, transform.position);

        Kv1 = new Vector2();
        Kv2 = new Vector2();
        Kv3 = new Vector2();
        Kv4 = new Vector2();
        Kr1 = new Vector2();
        Kr2 = new Vector2();
        Kr3 = new Vector2();
        Kr4 = new Vector2();
        Vector2 V = body.velocity;

        for (int i = 0; n > i; i++)
        {
            iter++;
            Kr1 = V;
            Kv1 = (M * (R/Mathf.Pow(R.magnitude,3)));
            Kr2 = V + Kv1 * h / 2;
            Kv2 = (M * (R / Mathf.Pow(R.magnitude, 3))) + Kr1 * h / 2;
            Kr3 = V + h * Kv2 / 2;
            Kv3 = (M * (R / Mathf.Pow(R.magnitude, 3))) + Kr2 * h / 2;
            Kr4 = V + h * Kv3;
            Kv4 = (M * (R / Mathf.Pow(R.magnitude, 3))) + Kr3 * h;

            R = R + (Kr1 + Kr2 + Kr3 + Kr4) * h / 6;
            V = V + (Kv1 + Kv2 + Kv3 + Kv4) * h / 6;

            VGsum[i] = V;
            
        }

        return VGsum;
    }

    Vector2 V(float t, float h)
    {

        float n = t / h;
        int N = (int)Mathf.Round(n);
        iter++;
        return body.velocity + h * Asum[N];
    }

    Vector2 X(float t, float h)
    {
        
        float n = t / h;
        int N = (int)Mathf.Round(n);
        iter++;
        return body.position + h * (Vsum[N] + VGsum[N]);
    }

    public void test()
    {
        Vector3[] Points = new Vector3[EstimatedTime];

        float h = Time.fixedDeltaTime;

        _Asum(EstimatedTime, h);
        _Vsum(EstimatedTime, h);
        _VGsum(EstimatedTime, h);

        for (int i = 0; EstimatedTime > i; i++)
        {
            
            Vector2 Coords = X(i, h);
            

            Points[i] = new Vector3(Coords.x, Coords.y, 0);

        }
        Debug.Log(iter);
        Line.SetPositions(Points);
    }

}
