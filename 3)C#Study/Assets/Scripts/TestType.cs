using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TestType : MonoBehaviour
{
    // 변수 선언
    public int a; //접근제한자 public, 다른 코드에서 접근 가능
    private int b; // private, 자기 class만 접근 가능

    // 정수 타입 자료형
    short shortNum = 0; // 2Byte 
    int intNum = 1; // 4
    uint uintNum = 2; // 4
    long longNum = 3; // 8

    // 실수
    float floatNum = 0.0f;
    double doubleNum = 1.5f;
    decimal decimalNum = 1000.000M;

    // 문자
    char charStr = 'a'; // 2byte
    string stringStr = "string";

    // 진리
    bool isBool = true;
    byte bt;

    object o; //인스턴스 타입 변수
    
    private void Start() {
       // int c = 0; // 지역 변수   
        Debug.Log("short : " + short.MinValue + ", " + short.MaxValue);
        Debug.Log("int : " + int.MinValue + ", " + int.MaxValue);
        Debug.Log("uint : " + uint.MinValue + ", " + uint.MaxValue);
        Debug.Log("long : " + long.MinValue + ", " + long.MaxValue);
        
        Debug.Log("flaot : " + float.MinValue + ", " + float.MaxValue);
        Debug.Log("double : " + double.MinValue + ", " + double.MaxValue);
        Debug.Log("decimal : " + decimal.MinValue + ", " + decimal.MaxValue);
        
        int a = 3;
        int b = 10;
        Debug.Log("a + b = " + (a + b));

        string str1 = "hello";
        string str2 = "hi";
        string text = "{0} {1}";
        Debug.Log(string.Format(text, str1, str2));

        StringBuilder sb = new StringBuilder();
        sb.Append(str1);
        sb.Append(str2);
        Debug.Log(sb);


        // boxing / unboxing
        object intObject;
        intObject = intNum; // object <- int (힙공간에 스택 자원을 할당 : boxing)
        int newInt = (int)intObject; // int <- object (스택공간에 힙 자원 할당 : unboxing)


    }
}
