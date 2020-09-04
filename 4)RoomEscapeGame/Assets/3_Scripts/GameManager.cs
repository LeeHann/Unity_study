using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 게임에 필요한 기능
    // 1. 물체를 클릭했을 때,
    //  문 : 열쇠(키 아이템)가 있으면 문이 열림, 없으면 열쇠가 없다고 텍스트 띄워주기
    //  서랍장 : 자물쇠가 있는 서랍장 -> 자물쇠를 열어야 열림, 열리지 않고 잠겼다고 알림
    //          없는 서랍장 -> 그냥 열림
    //  자물쇠 : 잠김 상태면 자물쇠 팝업 띄워주고, 열리면 사라짐
    //  메시지 텍스트 : 인터렉션이 되는 물체를 클릭했을 때, 안내 문구 띄워주기

    // 2. UI
    //  서랍장 내부 팝업 : 방금 누른 서랍장의 내부를 보여주기
    //  자물쇠 팝업 : 잠김 또는 잠김해제 상태를 텍스트로 보여줌, 버튼을 맞는 패스워드로 맞추면 잠김 해제
    //  인벤토리 : 가질 수 있는 아이템을 누르면 인벤토리로 아이템이 들어옴


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            Ray2D ray = new Ray2D(mousePos, Vector2.zero);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction); //부딪히는 모든 콜라이더 검출
            
            foreach(var hit in hits)
            {    
                switch(hit.transform.tag)
                {
                    case "Door" :
                        Debug.Log("문 클릭");
                        break;

                    case "Drawer" :
                        Debug.Log("서랍 클릭");
                        break;

                    case "Lock" :
                        Debug.Log("자물쇠 클릭");
                        break;

                    default :
                        break;
                }
            }
        }
    }
}
