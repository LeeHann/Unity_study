using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
  public string names;
  public char bloodType;
  public uint age;
  public float height;
  public bool isFemale;

  public void Say()
  {
    Debug.Log("캐릭터 이름 : " + names);
    Debug.Log("혈액형 : " + bloodType);
    Debug.Log("나이 : " + age);
    Debug.Log("키 : " + height);
    Debug.Log("여성인가? : " + isFemale);
  }
}
