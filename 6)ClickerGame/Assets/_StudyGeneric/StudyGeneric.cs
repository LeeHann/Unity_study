using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyGeneric : MonoBehaviour
{
    private void Start() {
        TextDisplay td = new TextDisplay();
        td.ShowText("Somethig", "like this", "into the array");
        td.ShowText("Can", "do this", "the", "difference of", "number");
    }

    public void TestGenericClass()
    {
        GameObject aObj = new GameObject();
        GameObject bObj = new GameObject();
        GameObject[] objArray = new GameObject[2]
        {
            aObj, bObj
        };

        GenericClass<GameObject> objGc = new GenericClass<GameObject>(aObj, objArray);

        aObj.name = "aObj";
        bObj.name = "bObj";
        
        Debug.Log("obj generic class");
        objGc.ShowMyThing();

        Vector2 aVec = new Vector2(1f, 2f);
        Vector2 bVec = new Vector2(3f, 4f);
        Vector2[] vecArray = new Vector2[2]
        {
            aVec, bVec
        };

        GenericClass<Vector2> vecGc = new GenericClass<Vector2>(aVec, vecArray);

        Debug.Log(" ---- vec generic class");
        vecGc.ShowMyThing();
    }

    public void TestGeneric()
    {
        int aInt = 7;
        float aFloat = Mathf.PI;

        char oneText = 'A';
        string textString = "Hello World";

        Vector2 twoPos = new Vector2(3f, 5f);
        Vector3 threePos = new Vector3(0f, 1f, 0f);

        ShowLog<int, char, Vector2>(aInt, oneText, twoPos);
        ShowLog<float, string, Vector3>(aFloat, textString, threePos);
    }

    // Generic method
    // 임의의 매개 변수 타입을 T, U, P를 만들고, 다양한 타입의 값을 받아올 수 있음
    void ShowLog<T, U, P>(T number, U text, P vector)
        where T : struct
        // where U : struct
        where P : System.IEquatable<P>
    {
        Debug.Log("number : " + number);
        Debug.Log("text : " + text);
        Debug.Log("vector : " + vector.ToString());
    }
}
