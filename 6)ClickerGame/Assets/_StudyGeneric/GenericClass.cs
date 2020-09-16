using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisplay
{
    //params 다음은 무조건 array
    public void ShowText(params string[] texts)
    {
        string textForShow = "";
        foreach(string t in texts)
        {
            textForShow += t;
        }
        Debug.Log(textForShow);
    }
}

public class GenericClass<T>
{
    T genericThing;
    T[] genericThings;

    // params 가변인자
    public GenericClass(T thing, params T[] things)
    {
        this.genericThing = thing;
        this.genericThings = things;
    }

    public void ShowMyThing()
    {
        Debug.Log(genericThing.ToString());
        
        foreach(T g in genericThings)
        {
            Debug.Log("genericThings : " + g.ToString());
        }
    }
}
