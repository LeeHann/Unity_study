using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RSP_GameManager : MonoBehaviour
{
    /*
    * 가위바위보 게임
        1. 내 손 버튼을 누르면 PC의 손이 랜덤하게 정해지고,
        2. 내가 낸 손 모양이랑 PC의 손 모양의 승패를 갈라서 결과를 텍스트로 보여줌. 

    * 추가 구현
        1. Hand[] pcHandPattern 배열을 만들고, 
    */

    public enum Hand
    {
        Rock = 0,
        Scissors = 1,
        Paper = 2,
        Max
    }

    public enum GameResult
    {
        Win = 0,
        Lose = 1,
        Draw = 2
    }

    Hand[] pcHandPattern = new Hand[10]
    {
        Hand.Rock,
        Hand.Paper,
        Hand.Scissors,
        Hand.Rock,
        Hand.Paper,
        Hand.Scissors,
        Hand.Rock,
        Hand.Paper,
        Hand.Scissors,
        Hand.Rock
    };

    public Image imgPcHand;
    public Sprite[] handSprites;
    public Text txtGameResult;
    public Color[] gameResultTextColors;
    public Text txtAllResult;
    
    int allGame, allWin, allLose;

    private void Start() {
        allGame = 0;
        allWin = 0;
        allLose = 0;
        txtGameResult.text = "";
    }

    public void ClickMyHandButton(int handInt)
    {
        allGame++;

        Hand myHand = (Hand)handInt;

        // Hand pcHand = (Hand)Random.Range(0, (int)Hand.Max);
        int pcHandInt = Random.Range(0, (int)Hand.Max);
        Hand pcHand = (Hand)pcHandInt;

        imgPcHand.sprite = handSprites[pcHandInt];
        
        GameResult result = GetGameResult(myHand, pcHand);
        switch(result)
        {
            case GameResult.Win :
                allWin += 1;
                break;

            case GameResult.Lose :
                break;

            case GameResult.Draw :
                break;
        }

        txtGameResult.color = gameResultTextColors[(int)result];
        

        string resultText = "총 {0} 회 대결\n<size=40><color=#FF698F>{1} 회 승</color> / {2} 회 패</size>";
        txtAllResult.text = string.Format(resultText, allGame, allWin, allLose);
    }

    GameResult GetGameResult(Hand myHand, Hand yourHand)
    {
        // 승패 체크 (+ 무승부)
        GameResult result;
        if (myHand == yourHand)
        {
            result = GameResult.Draw;
        }
        else if ((myHand == Hand.Rock && yourHand == Hand.Scissors)
               ||(myHand == Hand.Scissors && yourHand == Hand.Paper) 
               ||(myHand == Hand.Paper && yourHand == Hand.Rock))
        {
            result = GameResult.Win;
        }
        else
        {
            result = GameResult.Lose;
        }
        return result;
    }
}
