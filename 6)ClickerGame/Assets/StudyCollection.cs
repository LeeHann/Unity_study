using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyCollection : MonoBehaviour
{
    //ArrayList, Queue, Stack -> System.Collection

    int[] intArray = new int[10];
    ArrayList arrayList;

    // System.Collections.Generic : List, Dictionary, Queue, Stack ...
    List<string> stringList; // Generic <>, 인스턴스 타입
    Dictionary<string, Vector2> vectorDic; // 키 값으로 값을 관리하는 자료형 
    Stack<int> intStack;
    Queue<int> intQueue;

    void Start()
    {
        intStack = new Stack<int>();
        intQueue = new Queue<int>();

        intStack.Push(0);
        intStack.Push(1);
        intStack.Push(2);
        intStack.Push(3);
        
        intQueue.Enqueue(0);
        intQueue.Enqueue(1);
        intQueue.Enqueue(2);
        intQueue.Enqueue(3);
        
        int curInt = intStack.Peek(); // =top;
        Debug.Log(curInt);

        curInt = intQueue.Peek();   // =front;
        Debug.Log(curInt);
        
        int count = intStack.Count;
        for(int i=0; i<count; i++)
        {
            Debug.Log("intStack : " + intStack.Pop());
            Debug.Log("intQueue : " + intQueue.Dequeue());
        }

        
    }

    void StudyDictionary()
    {
        vectorDic = new Dictionary<string, Vector2>();

        vectorDic.Add("위", Vector2.up);
        vectorDic.Add("아래", Vector2.down);
        vectorDic.Add("왼쪽", Vector2.left);
        vectorDic.Add("오른쪽", Vector2.right);

        if(vectorDic.ContainsKey("위") == true)
        {
            Vector2 upVec = vectorDic["위"];
        }
        if(vectorDic.ContainsValue(Vector2.up) == true)
        {
            Vector2 upVec = vectorDic["위"];
        }

        foreach(KeyValuePair<string, Vector2> e in vectorDic)
        {
            Debug.Log(e.Key + " " + e.Value);
        }

        Debug.Log("-----------------");

        vectorDic.Remove("아래");
        vectorDic.Clear();

        foreach(KeyValuePair<string, Vector2> e in vectorDic)
        {
            Debug.Log(e.Key + " " + e.Value);
        }
    }

    void StudyList()
    {
        stringList = new List<string>(); // 두 번 이상 선언 시 이전에 선언한 것은 GC에 의해 처리
        stringList = new List<string>();

        stringList.Add("일");
        stringList.Add("이");
        stringList.Add("삼");
        stringList.Add("사");
        // 저장 값   : "일" | "이" | "삼" | "사"
        // 인덱스 값 :  0   |  1   |  2   |  3
        stringList.Remove("일");
        stringList.Remove("오"); //없는 요소는 지우지 않음 = 변화 없음
        // 저장 값   : "이" | "삼" | "사"
        // 인덱스 값 :  0   |  1   |  2  

        for(int i=0; i<stringList.Count; i++)
        {
            Debug.Log(stringList[i]);
        } // 이\n삼\n사\n
        
        Debug.Log("---------------------");

        stringList.Insert(2, "삼.오");

        for(int i=0; i<stringList.Count; i++)
        {
            Debug.Log(stringList[i]);
        } // 이\n삼\n삼.오\n사\n

        Debug.Log("---------------------");

        stringList.Clear();

        for(int i=0; i<stringList.Count; i++)
        {
            Debug.Log(stringList[i]);
        } Debug.Log("비움");

        string[] stringArray = stringList.ToArray(); //Array 반환
        stringList = new List<string>(stringArray); //List 생성자, 인덱스 맞춰서 배열을 리스트에 삽입
    }

    void StudyArrayList()
    {
        // 값 타입과 인스턴스 타입의 박싱 언 박싱이 빈번하게 이루어져 메모리 관리에 차질
        arrayList = new ArrayList();
        arrayList.Add(123); // int > 값 타입
        arrayList.Add("글자");
        arrayList.Add(new GameObject());
    }
}
