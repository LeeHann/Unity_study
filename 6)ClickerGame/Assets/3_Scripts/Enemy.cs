using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 1. maxHP, curHP
    // 2. Appear(), GetHit(), Dead()

    int maxHp;
    int curHp;
    bool isDead;

    [SerializeField] Animator animator;

    public void Appear(int maxHp)
    {
        this.maxHp = maxHp;
        curHp = maxHp;
        isDead = false;
    }

    public void GetHit(int damage)
    {
        if(isDead) return;
        animator.SetTrigger("GetHit");
        
        curHp -= damage;
        if(curHp <= 0)
        {
            Dead();
        }
        else
        {
            animator.SetTrigger("GetHit");
        }
    }

    void Dead()
    {
        animator.SetTrigger("Die");
        isDead = true;
        
        GameManager.Manager.UpdataEnemyDie();
        Destroy(this.gameObject, 2f);
    }

}
