using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockScissorPaper : MonoBehaviour
{
    // 열거형
    public enum Hand : int
    {
        rock = 0,
        scissor = 1,
        paper = 2,
        Max = 3
    };

    public enum GameResult
    {
        Win,
        Lose,
        Draw
    }

    // 0: 가위, 1: 바위, 2: 보
    public Hand player; // 플레이어가 낸 가위바위보 값
    public Hand pc; // 컴퓨터가 낸 가위바위보 값

    void Start()
    {
        
    }

    private void OnGUI() 
    {
        if(GUI.Button(new Rect(10,10,300,100), "가위"))
        {
            StratGame(Hand.scissor);
        }
        if(GUI.Button(new Rect(10,110,300,100), "바위"))
        {
            StratGame(Hand.rock);
        }
        if(GUI.Button(new Rect(10,220,300,100), "보"))
        {
            StratGame(Hand.paper);
        }
    }

    void StratGame(Hand hand)
    {
        pc = (Hand)Random.Range(0, (int)Hand.Max);
        player = hand;
        Debug.Log("나는 <" + GetHandText(player) + "> 를 냈다.");
        Debug.Log("컴퓨터는 <" + GetHandText(pc) + "> 를 냈다.");

        GameResult result;
        if(pc == player)
        {
            result = GameResult.Draw;
        }
        else if((pc == Hand.scissor) && (player == Hand.rock)
            || (pc == Hand.rock) && (player == Hand.paper) 
            || (pc == Hand.paper) && (player == Hand.scissor))
        {
            result = GameResult.Win;
        }
        else
        {
            result = GameResult.Lose;
        }

        switch(result)
        {
            case GameResult.Win :
                Debug.Log("플레이어가 이겼습니다.");
                break;
            
            case GameResult.Draw :
                Debug.Log("비겼습니다.");
                break;
            
            case GameResult.Lose :
                Debug.Log("플레이어가 졌습니다.");
                break;
            
            default:
                break;
        }
    }

    string GetHandText(Hand hand)
    {
        switch(hand)
        {
            case Hand.scissor :
                return "가위";
            
            case Hand.rock :
                return "바위";

            case Hand.paper :
                return "보";
            
            default :
                return "";
        }
    }
}
