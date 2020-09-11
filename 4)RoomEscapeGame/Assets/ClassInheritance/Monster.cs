using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster //추상 클래스
{
    protected string name;
    protected int hp;
    protected int damage;
    public string sound;

    public Monster(string name)
    {
        this.name = name;
    }

    protected void Attack()
    {
        Debug.Log("공격");
    }

    protected void Talk()
    {
        Debug.Log(sound + " 라고 말하기");
    }

    protected void Eat()
    {
        Debug.Log("먹기");
    }

    public abstract void Sleep(string sleepSound);

    public virtual void FindPlayerAction()
    {
        Debug.Log(name + "이(가) 플레이어를 만났다.");
    }
}

public class Orc : Monster, IArchor
{
    int defence;

    public Orc(string name, string sound, int defence) : base(name)
    {
        this.sound = sound;
        this.defence = defence;
    }

    public override void FindPlayerAction()
    {
        base.FindPlayerAction(); //부모가 구현해 둔 메서드를 실행

        Talk();
        Attack();
    }

    public void DoOnlyOrc()
    {
        Debug.Log("오크만 소리지르기");
    }

    public override void Sleep(string sleepSound)
    {
        Debug.Log(sleepSound);
        Debug.Log(sleepSound);
    }

    public void ShootBow()
    {
        Debug.Log("오크는 활을 따닷 쏜다.");
    }
}

public class Troll : Monster, IWalkable
{   
    public int walkedDistance { get {return 1;} }
    public void Walk()
    {
        Debug.Log("트롤은 터덜터덜 걷는다.");
    }

    public Troll(string name, int hp) : base(name)
    {
        this.hp = hp;
    }

    public override void FindPlayerAction()
    {
        base.FindPlayerAction();

        Eat();
        Attack();
    }

    public void DoOnlyTroll()
    {
        Debug.Log("트롤만 자연 회복");
    }

    public override void Sleep(string sleepSound)
    {
        Debug.Log(sleepSound + " zzzz... ");
    }
}