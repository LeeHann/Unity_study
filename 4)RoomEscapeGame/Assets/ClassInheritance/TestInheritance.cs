using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInheritance : MonoBehaviour
{

    void Start()
    {
        Orc orc = new Orc("지나가는 오크", "옼! 옼!", 10);
        Troll troll = new Troll("서 있는 트롤", 100);

        // Debug.Log("오크");
        // orc.FindPlayerAction();

        // Debug.Log("트롤");
        // troll.FindPlayerAction();

        // Monster monster = new Monster("뭔지 모를 몬스터"); // 추상 클래스는 단독 객체 생성 불가능
        // monster.FindPlayerAction();

        Monster[] monsters = new Monster[2];
        monsters[0] = orc; // 자식 클래스 -> 부모 클래스 : 업캐스팅
        monsters[1] = troll;

        // Orc newOrc = (Orc)monsters[0]; // 부모 클래스 -> 자식 클래스 : 다운캐스팅
        // monsters[0].DoOnlyOrc(); // 자식이 구현한 내용을 부모가 사용할 수 없음
        
        foreach(var mon in monsters)
        {
            mon.FindPlayerAction();
            mon.Sleep(mon.sound);
        }
    }
}
