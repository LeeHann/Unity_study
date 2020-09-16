using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    public int count = 3; // pooling에 만들어 놓는 갯수

    public float timeBetweenSpawnMin = 1.25f;
    public float timeBetweenSpawnMax = 2.25f;
    float timeBetSpawn;
    
    public float yMin = -3.5f;
    public float yMax = 1.5f;

    float xPos = 20f;

    GameObject[]  platforms;
    int curIndex = 0;
    
    Vector2 poolPosition = new Vector2(0f, -25f);
    float lastSpawnTime;

    private void Start() {
        platforms = new GameObject[count];
        for(int i=0; i<count; i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity); // prefab이 가진 고유의 값이 들어감.
        }
    }

    private void Update() {
        if(Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetweenSpawnMin, timeBetweenSpawnMax);

            float yPos = Random.Range(yMin, yMax);
            
            platforms[curIndex].SetActive(false);
            platforms[curIndex].SetActive(true);

            platforms[curIndex].transform.position = new Vector2(xPos, yPos);

            curIndex = (curIndex+1) % count;
        }
    }
}
