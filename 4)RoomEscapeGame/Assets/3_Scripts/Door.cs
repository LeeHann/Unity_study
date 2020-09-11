using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : OpenableProp, IClickable
{
    // 문 - 열쇠(키 아이템)가 있으면 문이 열리고, 없으면 열쇠가 없다고 텍스트(UI)로 띄워주기
//    GameManager manager;
    //void OnEnable() // 주로 초기화 코드를 작성
    public string keyName;
    public string doorName;
    public bool hasKey{ get; private set; }

    protected override void Start()
    {
        //manager = GameManager.Manager; // 캐싱 (최적화)
        base.Start();
        Close();
        hasKey = false;
    }

    public bool SetHasKey(string gotKey)
    {
        if(keyName == gotKey)
        {
            hasKey = true;
            GameManager.Manager.ShowNotice(doorName + "의 열쇠를 얻었습니다.");
        }
        return hasKey;
    }

    public void OnClick()
    {
        if(hasKey)
        {
            Open();
            GameManager.Manager.ShowEscape();
        }
        else
        {
            GameManager.Manager.ShowNotice("문이 잠겨있습니다.");
        }
    }
}
