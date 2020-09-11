using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Mover
{   
    public float speed = 8f;
    public Rigidbody rigid;
    public override void Move()
    {
        float xInput = Random.Range(0f, 1f);
        float zInput = Random.Range(0f, 1f);

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);
        rigid.velocity = newVelocity;
    }

    public override void Stop()
    {
        Vector3 newVelocity = new Vector3(0f, 0f, 0f);
        rigid.velocity = newVelocity;
    }
}
