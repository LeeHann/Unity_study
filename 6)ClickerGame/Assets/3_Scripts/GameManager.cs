using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 1. 처치한 적의 수, 적이 등장한 이후 지난 시간, 적을 처치하는데 주어지는 시간
    // 2. 적 스폰(), 적이 죽었을 때 시간 처리(), 총 처치한 적의 수 카운팅()

    private static GameManager manager;
    public static GameManager Manager{
        get{
            if (manager == null)
            {
                manager = FindObjectOfType<GameManager>();
            }
            return manager;
        }
    }
    int deadEnemy;
    int DeadEnemy
    {
        set {
            deadEnemy = value;
            uiManager.UpdateKillCount(deadEnemy);
        }
        get{
            return deadEnemy;
        }
    }

    Enemy curEnemy;
    int myCoin;
    int Coin
    {
        set {
            myCoin = value;
            uiManager.UpdateCoin(myCoin);
            PlayerPrefs.SetInt("Coin", myCoin);
        }
        get {return myCoin;}
    }

    const float timeForKillEnemy = 5f;
    float curTime;

    [SerializeField] GameObject[] EnemyPrefabs;
    [SerializeField] Transform spawnEnemyPos;
    [SerializeField] Player player;
    [SerializeField] UIManager uiManager;

    


    private void Start() {
        Coin = PlayerPrefs.GetInt("Coin", 0);
        DeadEnemy = 0;
        curTime = 0;

        player.Init(PlayerPrefs.GetInt("Level", 1), PlayerPrefs.GetInt("EXP", 0));
        SpawnEnemy();
    }

    void Update()
    {
        SpendTime();
    }

    void SpendTime()
    {
        if(curEnemy == null || curEnemy.isDead == true) {return;}

        curTime += Time.deltaTime;
        uiManager.UpdateTime(timeForKillEnemy, curTime);

        if(curTime >= timeForKillEnemy)
        {
            curTime = 0;
            
            // 실패 처리
            curEnemy.Disappear();
            Invoke("SpawnEnemy", 1f);
        }
    }

    void SpawnEnemy()
    {
        curTime = 0;
        uiManager.UpdateTime(timeForKillEnemy, curTime);

        int randomIndex = Random.Range(0, EnemyPrefabs.Length);

        GameObject enemyObj = Instantiate(EnemyPrefabs[randomIndex], spawnEnemyPos);
        curEnemy = enemyObj.GetComponent<Enemy>();
        curEnemy.Appear(10);

        player.SetTarget(curEnemy);
    }

    public void UpdateEnemyDie(int getCoin)
    {
        DeadEnemy += 1;
        Coin += getCoin;
        Invoke("SpawnEnemy", 2f);
    }
}
