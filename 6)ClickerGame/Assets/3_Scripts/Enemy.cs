﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackAttrib
{
    None,
    Water,
    Fire,
    Wind,
}

public class Enemy : MonoBehaviour
{
    // 1. maxHP, curHP
    // 2. Appear(), GetHit(), Dead()
    [SerializeField] Animator animator;
    [SerializeField] GameObject efcDamagePrefab;
    [SerializeField] GameObject efcCoinPrefab;


    [Header("enemy info")]
    
    static int level;
    public static int Level
    {
        set
        {
            level = value;
            PlayerPrefs.SetInt("Enemy Level", level);
        }
        get
        {
            return PlayerPrefs.GetInt("Enemy Level", 1);
        }
    }

    [SerializeField] int baseCoin;
    public int Coin
    {
        get{ return baseCoin * Level;}
    }

    [SerializeField] AttackAttrib attackAttrib;
    public bool isDead {private set; get;}
    int maxHp;
    int curHp;
    

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

    public void GetHit(AttackInfo attackInfo)
    {
        if(isDead) return;

        int damage = attackInfo.GetDamage(attackAttrib);
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
        Instantiate(efcCoinPrefab, transform);
        
        GameManager.Manager.UpdateEnemyDie(Coin);
        
        Destroy(this.gameObject, 2f);
    }

}
