using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
  int aInt = 0; //정수
  int bInt = 1;
  long aLong = 9999999;
  float aFloat = 0.0f; //실수
  double aDouble = 0.1f;
  bool isA = true; //진리값
  GameObject aObj = null; //게임 오브젝트
  char aChar = 'A'; //문자
  string sString = "Hello Unity"; //문자열

  // Start is called before the first frame update
  void Start()
  {
    int aa = AddNumbers(1, 2);
    int bb = AddNumbers(3, 4, 5);

    Debug.Log("aa : " + aa);
    Debug.Log("bb : " + bb);
    
    Debug.Log("aa : " + aa + ", bb : " + bb);
  }

  int AddNumbers(int a, int b)
  {
    return a + b;
  }
  int AddNumbers(int a, int b, int c)
  {
    return AddNumbers(a, b) + c;
  }
}
