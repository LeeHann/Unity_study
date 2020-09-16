using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public bool isGameover {private set; get;}
    [SerializeField] Text scoreText;
    [SerializeField] GameObject gameoverUI; //텍스트 UI의 활성화를 관리할 게임 오브젝트

    int score = 0;

    private void Update() {
        if(isGameover && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

    public void AddScore(int newScore)
    {
        if(isGameover == false)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }

    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }
}
