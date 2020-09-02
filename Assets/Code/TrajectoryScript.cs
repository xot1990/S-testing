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


    void Start()
    {
        body = transform.GetComponent<Rigidbody2D>();
        Line = GetComponent<LineRenderer>();
        EstimatedTime = 50;
        Line.positionCount = EstimatedTime;
        
    }

    
    void Update()
    {
        Debug.Log(Vector3.Project(body.velocity, transform.right).magnitude * 50);
        Debug.Log(A.magnitude * Mathf.Pow(50, 2) / 2);

    }

    private void FixedUpdate()
    {
        A = (body.velocity - lastVelocity) / Time.deltaTime;
        lastVelocity = body.velocity;

        Trajectory();
    }

    public void Trajectory()
    {
        Vector3[] Points = new Vector3[EstimatedTime];

        for (int i = 0; EstimatedTime > i; i++)
        {
            float X = body.position.x + Vector3.Project(body.velocity, transform.up).magnitude * i + (Vector3.Project(A, transform.up).magnitude * Mathf.Pow(i, 2) / 2);
            float Y = body.position.y + Vector3.Project(body.velocity, transform.right).magnitude * i + (Vector3.Project(A, transform.right).magnitude * Mathf.Pow(i, 2) / 2);

            Points[i] = new Vector3(X, Y, 0);
        }
        Line.SetPositions(Points);
    }
}
