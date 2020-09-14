using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text txtKillCount;
    [SerializeField] Image gaugeTime;

    public void UpdateKillCount(int killCount)
    {//UI 창, 죽인 적의 수
        txtKillCount.text = killCount.ToString();
    }

    public void UpdateTime(float maxTime, float spendTime)
    {
        float leftTime = (maxTime - spendTime) / maxTime;
        gaugeTime.fillAmount = leftTime;
    }
}
