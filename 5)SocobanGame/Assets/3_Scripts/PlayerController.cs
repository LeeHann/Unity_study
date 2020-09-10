using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    public float speed = 5f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 movePos = (new Vector3(inputX, 0, inputZ)).normalized * speed;
        //Time.deltaTime : 프레임률에 따른 보정 값
        rigidbody.MovePosition(transform.position + movePos * Time.deltaTime);
    }
}
