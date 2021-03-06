﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /*
    게임에 필요한 기능
    1. 물체를 클릭했을 때,
     문 : 열쇠(키 아이템)가 있으면 문이 열림, 없으면 열쇠가 없다고 텍스트 띄워주기
     서랍장 : 자물쇠가 있는 서랍장 -> 자물쇠를 열어야 열림, 열리지 않고 잠겼다고 알림
             없는 서랍장 -> 그냥 열림
     자물쇠 : 잠김 상태면 자물쇠 팝업 띄워주고, 열리면 사라짐
     메시지 텍스트 : 인터렉션이 되는 물체를 클릭했을 때, 안내 문구 띄워주기

    2. UI
     서랍장 내부 팝업 : 방금 누른 서랍장의 내부를 보여주기
     자물쇠 팝업 : 잠김 또는 잠김해제 상태를 텍스트로 보여줌, 버튼을 맞는 패스워드로 맞추면 잠김 해제
     인벤토리 : 가질 수 있는 아이템을 누르면 인벤토리로 아이템이 들어옴

    property : get, set 사용
               1. 변수의 값을 바꾸거나 가져올 때 메서드처럼 처리하고 싶을 때
               2. 다른 코드에서 마음대로 바꾸면 안 되는 값을 보호하고 싶을 때
    singleton : 디자인 패턴
               1. 메모리 상에 하나만 존재해야 하는 객체를 관리할 때
               2. 다른 코드에서 직접 참조하지 않고 사용할 수 있게 만들 때
    */
    private static GameManager manager;
    public static GameManager Manager
    {
        get
        {
            return manager;
        }

        private set
        {
            if(manager == null)
            {
                manager = value;
                DontDestroyOnLoad(manager);
            }
            else
                Destroy(value.gameObject);
        }
    }

    bool isPopupOn;
    public GameObject escapePopup;
    public Text textNotice;
    public Transform inventory; //image로 만들어진 inventory의 위치
    public GameObject itemSlotPrefab;
    public List<Door> doors;

    private void Awake() 
    {
        manager = this;
        isPopupOn = false; 
    }

    void Update()
    {
        if(isPopupOn == true) return ;

        if (Input.GetMouseButtonDown(0)) // Left
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            Ray2D ray = new Ray2D(mousePos, Vector2.zero);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction); //부딪히는 모든 콜라이더 검출
            
            foreach(var hit in hits)
            {    
                IClickable clickable = hit.transform.GetComponent<IClickable>();
                if (clickable != null)
                {
                    clickable.OnClick();
                }
            }
        }
    }
    
    public void PutInItem(GameObject item)
    {
        string itemId = item.name;

        foreach(var door in doors)
        {
            if (door.SetHasKey(itemId) == true) item.SetActive(false);
        }

        switch(itemId)
        {
            case "Item-Key" :
                item.SetActive(false);
                break;
        }
        Image itemImg = item.GetComponent<Image>();
        GameObject slotObj = Instantiate(itemSlotPrefab, inventory); // gameobject를 만드는 함수
        
        RectTransform slotTrans = slotObj.GetComponent<RectTransform>();
        slotTrans.anchoredPosition = new Vector2(0f,0f); //RectTransform 에서 화면 정렬하는 기능을 사용하기 위한 함수

        UIItemSlot slot = slotObj.GetComponent<UIItemSlot>(); // C# scripts component
        slot.UpdateSlot(itemImg.sprite);
    }

    //팝업이 떠 있는지 확인하기
    public void SetPopupOn(bool isOn)
    {
        isPopupOn = isOn;
    }
    
    public void ShowNotice(string notice)
    {
        textNotice.text = notice;
    }

    public void ShowEscape()
    {
        escapePopup.SetActive(true);
        SetPopupOn(true);
    }
}
