using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 1. 게임 오버가 되면 게임 오버 창(최고 스코어와 함께)을 띄움
    // 2. 게임이 시작된 이후부터 얼마나 시간이 지났는지 표시
    // 3. 최고로 오래 버틴 시간을 저장
    // 4. 게임 오버가 됐을 때, 'R' 버튼을 누르면 게임 재시작 (=씬을 다시 로드)

    public Text txtTime;
    public Text txtBestTime;
    public GameObject gameOverPanel;
    private float surviveTime;
    private bool isGameOver;

    void Start()
    {
        surviveTime = 0f;
        isGameOver = false;
    }

    void Update()
    {
        if (!isGameOver)
        {
            surviveTime += Time.deltaTime;
            txtTime.text = "시간 : " + (int)surviveTime;
        }
        
        if(Input.GetKeyDown(KeyCode.R) && isGameOver)
        {
            SceneManager.LoadScene("1)Game"); // = 0
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime", surviveTime); // access user preference information
        
        if(surviveTime >= bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime); // store information
        }
        txtBestTime.text = "최고 점수 : " + (int)bestTime;
    }
}
