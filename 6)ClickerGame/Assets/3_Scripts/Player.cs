using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 1. 레벨↑, 경험치, 공격력↑
    // 2. 공격(), 경험치업(), 레벨업()

    [SerializeField] AttackAttrib attackAttrib;
    

    
    [Header("player info")] //인스펙터 창을 정리하는 용도, 인스펙터 창에 라벨링이 됨
    [SerializeField] private Animator animator;
    [SerializeField] int power = 3;
    int level;
    int exp;
    

    Enemy target;


    public void Init(int level, int exp)
    {
        this.level = level;
        this.exp = exp;
    }

    public void SetTarget(Enemy enemy)
    {
        target = enemy;

    }

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) == true)
        {
            Attack();
        }
    }

    void Attack()
    {
        if (target == null) return;

        animator.SetTrigger("Attack");
        target.GetHit(new AttackInfo(attackAttrib, power));
    }
}
