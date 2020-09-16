using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Player : Attacker
{
    // 1. 레벨↑, 경험치, 공격력↑
    // 2. 공격(), 경험치업(), 레벨업()

    // [Header("player info")] //인스펙터 창을 정리하는 용도, 인스펙터 창에 라벨링이 됨

    protected override string GetSaveLevelKey()
    {
        return "Player Level";
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) == true)
        {
            Attack();
        }
    }

    protected override void Attack()
    {
        base.Attack();
        animator.SetTrigger("Attack");
    }
}
