using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // 문 - 열쇠(키 아이템)가 있으면 문이 열리고, 없으면 열쇠가 없다고 텍스트(UI)로 띄워주기

    SpriteRenderer renderer;
    
    public Sprite spriteDoorClose;
    public Sprite spriteDoorOpen;

//    GameManager manager;
    //void OnEnable() // 주로 초기화 코드를 작성

    void Start()
    {
        //manager = GameManager.Manager; // 캐싱 (최적화)
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = spriteDoorClose;
    }

    public void ClickDoor(bool hasKey)
    {
        if(hasKey)
        {
            renderer.sprite = spriteDoorOpen;
        }
        else
        {
            GameManager.Manager.ShowNotice("문이 잠겨있습니다.");
        }
    }
}
