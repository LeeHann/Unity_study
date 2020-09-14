using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_class : MonoBehaviour, IMover
{
    public float speed;
    protected bool isMove;
    protected Vector3 destination;

    private void Start() {
        isMove = true;
        destination = new Vector3(0f, 0f, 0f);
    }

    private void Update() {
        if(isMove == true)
        {
            Move();
        }
    }
    public void Move()
    {
        if(Vector3.Distance(transform.position, destination) < 1f)
        {
            SetNewDestination();
        }

        Vector3 dir = (destination - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }

    public void Stop()
    {
        isMove = false;
    }

    protected void SetNewDestination()
    {
        float randomX = Random.Range(-20f, 20f);
        float randomZ = Random.Range(-20f, 20f);
        destination = new Vector3(randomX, 0f, randomZ);
        Debug.Log(gameObject.name + " 자동차 목적지 : " + destination);
    }
}
