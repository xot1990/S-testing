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
    public float K = 1f;
    Vector2[] Vsum;
    Vector2[] Asum;
    Vector2[] VGsum;
    Vector2[] VGSsum;
    bool GravityOn;
    int k;
    int Y; 
    public GameObject Spot;
    public bool Grav;
    Vector2 Vstart;
    public float R;

    Vector2 Kv1;
    Vector2 Kv2;
    Vector2 Kv3;
    Vector2 Kv4;
    Vector2 Kr1;
    Vector2 Kr2;
    Vector2 Kr3;
    Vector2 Kr4;
    Vector2 Rg;

    void Start()
    {
        body = transform.GetComponent<Rigidbody2D>();
        Line = GetComponent<LineRenderer>();
        EstimatedTime = 500;
        
        
    }

    
    void Update()
    {
        



    }

    private void FixedUpdate()
    {
        
        A = Forces / body.mass;

        R = Vector2.Distance(body.position, GravityObj.position);
        if (R < 500)
        {
            GravityOn = true;
            body.AddForce(Gforce());
        }
        else GravityOn = false;
        

        Forces = Vector2.zero;
       
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
            
            sum += V((0 + (i - 1) * h) + h / 2, h);           

            Vsum[i] = sum;
        }
       
        return Vsum;
    }

     

    Vector2[] _VGsum(float t, float h)
    {
        M = K * GravityObj.mass;
        float n = t / h;
        int N = (int)Mathf.Round(n);
        Vector2 sum = new Vector2();
        VGsum = new Vector2[N];
        Vector2 D = -GravityObj.position + body.position;
        D.Normalize();

        Rg =  D * Vector2.Distance(GravityObj.position, body.position);

        Kv1 = new Vector2();
        Kv2 = new Vector2();
        Kv3 = new Vector2();
        Kv4 = new Vector2();
        Kr1 = new Vector2();
        Kr2 = new Vector2();
        Kr3 = new Vector2();
        Kr4 = new Vector2();
        Vector2 V = body.velocity;

        for (int i = 0; N > i; i++)
        {
            
            Kr1 = V;
            Kv1 = -M * (Rg/Mathf.Pow(Rg.magnitude,3));
            Kr2 = V + (Kv1 / 2) * h + A;
            Kv2 = -M * ((Rg + ((Kr1 / 2) * h)) / Mathf.Pow((Rg + ((Kr1 / 2) * h)).magnitude, 3)) + A;
            Kr3 = V + (h / 2) * Kv2;
            Kv3 = -M * ((Rg + ((Kr2 / 2) * h)) / Mathf.Pow((Rg + ((Kr2 / 2) * h)).magnitude, 3)) + A;
            Kr4 = V + h * Kv3;
            Kv4 = -M * ((Rg+ ((Kr3 / 2) * h)) / Mathf.Pow((Rg + ((Kr3 / 2) * h)).magnitude, 3)) + A;

            Rg = Rg + (Kr1 + 2*Kr2 + 2*Kr3 + Kr4) * (h / 6);
            V = V + (Kv1 + 2*Kv2 + 2*Kv3 + Kv4) * (h / 6);
            sum += V;
            VGsum[i] = sum;
            
        }

        return VGsum;
    }

    
    Vector2 Gforce()
    {
        
        Vector2 Force = new Vector2();
        Vector2 D = GravityObj.position - body.position;
        D.Normalize();
        float R = Vector2.Distance(body.position, GravityObj.position);        
        Force = D * (body.mass * GravityObj.mass / Mathf.Pow(R, 2));
        return Force;
    }
     
    Vector2 V(float t, float h)
    {

        float n = t / h;
        int N = (int)Mathf.Round(n);
        
        return body.velocity + h * Asum[N];
    }


    Vector2 Xv(float t, float h)
    {
        
        float n = t / h;
        int N = (int)Mathf.Round(n);               
        return body.position + h * Vsum[N];
    }

    Vector2 Xg(float t, float h)
    {
        
        float n = t / h;
        int N = (int)Mathf.Round(n);        
        return body.position + h * VGsum[N];
    }

    public void test()
    {
        List<Vector3> Points = new List<Vector3>();
        
       
        float h = Time.fixedDeltaTime;
        
        _Asum(EstimatedTime, h);
        _Vsum(EstimatedTime, h);
        _VGsum(EstimatedTime, h);
        


        if (GravityOn)
        {
            for (int i = 0; EstimatedTime > i; i++)
            {
                Vector2 Coords = Xg(i, h);
                if (Vector2.Distance(Coords, GravityObj.position) > 500) break;
                Points.Add(new Vector3(Coords.x, Coords.y, 0));
            }
        }

        if (!GravityOn)
        {
            for (int i = 0; EstimatedTime > i; i++)
            {
                Vector2 Coords = Xv(i, h);
                if (Vector2.Distance(Coords, GravityObj.position) < 500) break;
                Points.Add(new Vector3(Coords.x, Coords.y, 0));
            }
            
        }
        
        Line.positionCount = Points.Count;
        Line.SetPositions(Points.ToArray());
        
    }

}
