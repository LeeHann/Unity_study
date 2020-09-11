using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    //자동차, 비행기 생성

    public GameObject carPrefab;
    public Transform stage;
    Car[] car;
    Airplane plane;

    void Start()
    {
        Car[] car = new Car[3];

        Airplane plane = new Airplane();

    
    }

    void Update()
    {
        for(int i=0; i<car.Length; i++)
        {
            car[i].Move();
            // car[i].Stop();
        }
        plane.Move();
        // plane.Stop();
    }
}
