using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 8f;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            playerRigidbody.AddForce(0f,0f,speed);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
           playerRigidbody.AddForce(0f,0f,-speed);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
           playerRigidbody.AddForce(-speed,0f,0f);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
           playerRigidbody.AddForce(speed,0f,0f);
        }
    }
}
