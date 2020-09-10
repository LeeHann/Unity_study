using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private void Start() {
        
    }
    void Update()
    {
        transform.Rotate(60*Time.deltaTime,60*Time.deltaTime,60*Time.deltaTime);
    }
}
