using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 1. 레벨↑, 경험치, 공격력↑
    // 2. 공격(), 경험치업(), 레벨업()

    int level;
    int exp;
    [SerializeField] int power = 3;
    [SerializeField] private Animator animator;
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
        target.GetHit(power);
    }
}
