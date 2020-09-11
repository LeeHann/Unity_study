using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 한정자
//partial : 한 클래스를 나눠서 작업할 수 있음
//sealed : 상속 제한(파생 금지)
//override : 상속된 메서드, 추상 또는 가상 구현을 확장하거나 수정할 수 있게 함
//virtual :  선언을 수정하고 파생 클래스에서 재정의하도록 허용

public class TestInheritance : MonoBehaviour
{

    void Start()
    {
        IArchor[] archors = new IArchor[2];

        Orc orc = new Orc("오크 궁수", "옼!", 100);
        Hero hero = new Hero();

        archors[0] = orc;
        archors[1] = hero;

        foreach(var a in archors)
        {
            a.ShootBow();
        }

        IWalkable[] walkers = new IWalkable[2];
        Troll troll = new Troll("걷는 트롤", 150);

        walkers[0] = hero;
        walkers[1] = troll;

        foreach(var w in walkers)
        {
            w.Walk();
            Debug.Log("걸어온 거리 : " + w.walkedDistance);
        }
    }

    void Test()
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
