using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // 총알이 랜덤한 주기로 생성
    // 맞출 대상을 향해 총알 발사

    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f; //최소 총알 생성 주기
    public float spawnRateMax = 3f; //최대 생성 주기

    private Transform target; // 대상의 위치
    private float spawnRate; // 생성 주기
    private float timeAfterSpawn; //최근 생성 이후 흐른 시간

    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
        SetRandomSpawnRate();
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            GameObject newObj = Instantiate(bulletPrefab, transform.position, transform.rotation); // 총알 생성  
            
            newObj.transform.LookAt(target);

            timeAfterSpawn = 0f;
            SetRandomSpawnRate();
        }
    }
    void SetRandomSpawnRate()
    {
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }
}
