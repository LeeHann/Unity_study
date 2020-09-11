using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IArchor
{
    //인터페이스에 변수 선언 불가능, 프로퍼티, 메서드 선언만 가능
    //인터페이스에 선언되는 프로퍼티와 메서드는 접근 제한자를 쓰지 않음
    void ShootBow();
}

public interface IWalkable
{
    int walkedDistance { get; }
    void Walk();
}

public class Hero : IArchor, IWalkable
{
    void Attack()
    {

    }

    public void ShootBow() // 인터페이스 메서드 구현은 무조건 public 
    {
        Debug.Log("히어로가 활을 쏜다.");
    }

    public int walkedDistance
    {
        get { return 0;}
    }

    public void Walk()
    {
        Debug.Log("히어로도 터덜터덜 걷는다.");
    }
}
