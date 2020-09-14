using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 1. maxHP, curHP
    // 2. Appear(), GetHit(), Dead()

    int maxHp;
    int curHp;
    public bool isDead {private set; get;}

    [SerializeField] Animator animator;
    [SerializeField] GameObject efcDamagePrefab;

    public void Appear(int maxHp)
    {
        this.maxHp = maxHp;
        curHp = maxHp;
        isDead = false;
    }

    public void Disappear()
    {
        Destroy(this.gameObject);
    }

    public void GetHit(int damage)
    {
        if(isDead) return;
        animator.SetTrigger("GetHit");
        
        curHp -= damage;
        
        // 몬스터 피격 시 체력 감소 이펙트
        GameObject efcObj = Instantiate(efcDamagePrefab, transform);
        UIEffectText efcText = efcObj.GetComponent<UIEffectText>();
        efcText.UpdateText((damage*-1).ToString());

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
        
        GameManager.Manager.UpdateEnemyDie();
        Destroy(this.gameObject, 2f);
    }

}
