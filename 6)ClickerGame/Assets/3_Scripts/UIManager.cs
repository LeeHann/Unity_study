using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text txtKillCount;
    [SerializeField] Image gaugeTime;
    [SerializeField] Text txtCoin;

    [Header("Level Up Buttons")]
    [SerializeField] Text txtPlayerLevelInfo;
    [SerializeField] Text txtEnemyLevelInfo;
    [SerializeField] Text txtPetLevelInfo;
    

    [SerializeField] Text txtPlayerLevelUpPrice;
    [SerializeField] Text txtEnemyLevelUpPrice;
    [SerializeField] Text txtPetLevelUpPrice;

    public void UpdateKillCount(int killCount)
    {// UI 창, 죽인 적의 수
        txtKillCount.text = killCount.ToString();
    }

    public void UpdateTime(float maxTime, float spendTime)
    {
        float leftTime = (maxTime - spendTime) / maxTime;
        gaugeTime.fillAmount = leftTime;
    }

    public void UpdateCoin(int coin)
    {
        txtCoin.text = coin.ToString();
    }

    // 플레이어
    public void UpdatePlayerLevelUpButton(int curLevel, int curDamage, int nextDamage, int price)
    {
        //레벨 업
        txtPlayerLevelInfo.text = GetAttackerLevelInfo(curLevel, curDamage, nextDamage);
        
        //가격
        txtPlayerLevelUpPrice.text = price.ToString();
    }
    
    // 펫
    public void UpdatePetLevelUpButton(int curLevel, int curDamage, int nextDamage, int price)
    {
        txtPetLevelInfo.text = GetAttackerLevelInfo(curLevel, curDamage, nextDamage);
        txtPetLevelUpPrice.text = price.ToString();
    }
    
    // 적
    string GetAttackerLevelInfo(int curLevel, int curDamage, int nextDamage)
    {
        return string.Format("Lv.{0} > <b>{1}</b>\n<size=40>(dam : {2} > {3})</size>", curLevel, (curLevel+1), curDamage, nextDamage);
    }

    public void UpdateEnemyLevelUpButton(int price)
    {
        string info = string.Format("Lv.{0} > <b>{1}</b>\n<size=40>( {2}배 추가 획득 )</size>", Enemy.Level, Enemy.Level+1, Enemy.Level);
        txtEnemyLevelInfo.text = info;

        txtEnemyLevelUpPrice.text = price.ToString();
    }
}
