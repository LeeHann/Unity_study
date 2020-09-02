using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
  public float rotationSpeed = 60f;

  private void Update()
  {
    Vector3 rotationAngle = new Vector3(0f, rotationSpeed, 0f);
    transform.Rotate(rotationAngle * Time.deltaTime);
  }
}
