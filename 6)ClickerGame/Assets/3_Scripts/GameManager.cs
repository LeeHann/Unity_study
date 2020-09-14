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
    const float timeForKillEnemy = 5f;
    float curTime;

    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] Transform spawnEnemyPos;
    [SerializeField] Player player;

    private void Start() {
        deadEnemy = 0;
        curTime = 0;

        player.Init(PlayerPrefs.GetInt("Level", 1), PlayerPrefs.GetInt("EXP", 0));
        SpawnEnemy();
    }

    void Update()
    {
        curTime += Time.deltaTime;
        if(curTime >= timeForKillEnemy)
        {
            curTime = 0;
            
            // 실패 처리

            
        }
    }
    void SpawnEnemy()
    {
        GameObject enemyObj = Instantiate(EnemyPrefab, spawnEnemyPos);
        Enemy enemy = enemyObj.GetComponent<Enemy>();
        enemy.Appear(10);

        player.SetTarget(enemy);
    }

    public void UpdataEnemyDie()
    {
        deadEnemy += 1;

        Invoke("SpawnEnemy", 2f) ;
    }
}
