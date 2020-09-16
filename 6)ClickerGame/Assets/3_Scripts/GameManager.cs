using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // 1. 처치한 적의 수, 적이 등장한 이후 지난 시간, 적을 처치하는데 주어지는 시간
    // 2. 적 스폰(), 적이 죽었을 때 시간 처리(), 총 처치한 적의 수 카운팅()
    
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
    const int levelUpPrice = 10;

    [SerializeField] GameObject[] EnemyPrefabs;
    [SerializeField] Transform spawnEnemyPos;
    [SerializeField] Player player;
    [SerializeField] Pet pet;
    
    [SerializeField] UIManager uiManager;

    private void Start() {
        Coin = PlayerPrefs.GetInt("Coin", 0);
        DeadEnemy = 0;
        curTime = 0;

        SpawnEnemy();

        uiManager.UpdatePlayerLevelUpButton(player.Level, player.damage, player.GetNextDamage(1), (player.Level * levelUpPrice));
        uiManager.UpdateEnemyLevelUpButton(Enemy.Level * levelUpPrice);
        uiManager.UpdatePetLevelUpButton(pet.Level, pet.damage, pet.GetNextDamage(1), (pet.Level * levelUpPrice));
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
        pet.SetTarget(curEnemy);
    }

    public void UpdateEnemyDie(int getCoin)
    {
        DeadEnemy += 1;
        Coin += getCoin;
        Invoke("SpawnEnemy", 2f);
    }

    public void UpdatePlayerLevel(int upLevel)
    {
        if(UpdateAttackerLevel<Player>(player, upLevel))
            uiManager.UpdatePlayerLevelUpButton(player.Level, player.damage, player.GetNextDamage(1), player.Level * levelUpPrice);
    }

    //몬스터 레벨 올리기
    public void UpdateEnemyLevel(int upLevel)
    {
        int price = Enemy.Level * levelUpPrice; // Level 값이 static으로 클래스 자체적으로 저장되어 있어 클래스를 호출
        if(Coin >= price)
        {
            Coin -= price;

            Enemy.Level += upLevel;
            uiManager.UpdateEnemyLevelUpButton(price);
        }
    }

    // 펫 레벨 올리기
    public void UpdatePetLevel(int upLevel)
    {   
        if(UpdateAttackerLevel<Pet>(pet, upLevel))
            uiManager.UpdatePetLevelUpButton(pet.Level, pet.damage, pet.GetNextDamage(1), pet.Level * levelUpPrice);
    }

    bool UpdateAttackerLevel<A>(A attacker, int upLevel)
        where A : Attacker // new():인스턴스 타입, notnull : null 값이 들어갈 수 없는 타입, (ex/값 타입)
    {
        int price = attacker.Level * levelUpPrice;
        if(Coin >= price)
        {
            Coin -= price;

            attacker.UpdateLevel(upLevel);
            return true;
        }
        return false;
    }

    private void OnGUI() {
        if(GUI.Button(new Rect(10,10,100,30), "Remove"))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}