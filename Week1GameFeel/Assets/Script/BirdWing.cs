using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdWing : MonoBehaviour
{
    public float moveSpeed;
    public float leftAngle;
    public float rightAngle;
    private bool movingClockwise = false;

    public bool isFlapping = false;

    Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        movingClockwise = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlapping)
            Move();
        else
            rb.angularVelocity = 0;
    }

    public void ChangeMoveDir()
    {
        if (transform.rotation.z > rightAngle)
        {
            movingClockwise = false;
        }
        if (transform.rotation.z < leftAngle)
        {
            movingClockwise = true;
        }
    }

    public void Move()
    {
        ChangeMoveDir();

        if (movingClockwise)
        {
            rb.angularVelocity = moveSpeed;
        }
        else
        {
            rb.angularVelocity = moveSpeed * -1; 
        }
    }
}
