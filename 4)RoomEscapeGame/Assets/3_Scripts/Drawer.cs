using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    //  서랍장 : 자물쇠가 있는 서랍장 -> 자물쇠를 열어야 열림, 열리지 않고 잠겼다고 알림
    //          없는 서랍장 -> 그냥 열림

    public Sprite spriteOpenDrawer;
    public Sprite spriteCloseDrawer;
    public CombiLock combiLock;
    public GameObject drawerPopup;
    SpriteRenderer renderer;
    string[] lockMessages = new string[3] {"서랍이 잠겨있습니다.", "자물쇠를 풀어야 서랍을 열 수 있습니다.", "자물쇠를 먼저 푸세요!"};
    int curLockMessage = 0;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();    
        renderer.sprite = spriteCloseDrawer;

        if(drawerPopup) 
        {
            drawerPopup.SetActive(false);
        }
    }

    public void ClickDrawer()
    {
        if(combiLock != null && combiLock.IsLock == true)
        {
            GameManager.Manager.ShowNotice(lockMessages[curLockMessage]);
            curLockMessage = (curLockMessage + 1) % lockMessages.Length;
        }
        else
        {
            GameManager.Manager.ShowNotice("");
            renderer.sprite = spriteOpenDrawer;

            SetPopupOn(true);
        }
    }

    void SetPopupOn(bool isOn)
    {
        drawerPopup.SetActive(isOn);
        GameManager.Manager.SetPopupOn(isOn);
    }

    public void CloseDrawer()
    {
        SetPopupOn(false);
        renderer.sprite = spriteCloseDrawer;
    }
}
