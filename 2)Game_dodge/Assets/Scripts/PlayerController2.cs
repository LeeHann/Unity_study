using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float ySpeed = yInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, ySpeed, 0f);
        playerRigidbody.velocity = newVelocity;

        //transform.position = new Vector3(transform.position.x+xSpeed, transform.position.y+ySpeed, 0f);
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
