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
        Win,Lose,Draw
    }

    // 0: 가위, 1: 바위, 2: 보
    public Hand player; // 플레이어가 낸 가위바위보 값
    public Hand pc; // 컴퓨터가 낸 가위바위보 값, enum 타입
    public Hand[] pcs; // array : 인스턴스 타입
    public int numOfPcs = 10;

    // public GameResult playerOne;
    // public GameResult playerTwo;

    private void Start() 
    {
        pcs = new Hand[numOfPcs];
    }

    private void OnGUI() 
    {
        if(GUI.Button(new Rect(10,10,300,100), "가위"))
        {
            StartGame(Hand.scissor, pc);
        }
        if(GUI.Button(new Rect(10,120,300,100), "바위"))
        {
            StartGame(Hand.rock, pc);
        }
        if(GUI.Button(new Rect(10,230,300,100), "보"))
        {
            StartGame(Hand.paper, pc);
        }
        if(GUI.Button(new Rect(330,10,300,100), "단체전 가위"))
        {
            DoTeamPlay(Hand.scissor);
        }
        if(GUI.Button(new Rect(330,120,300,100), "단체전 바위"))
        {
            DoTeamPlay(Hand.rock);
        }
        if(GUI.Button(new Rect(330,230,300,100), "단체전 보"))
        {
            DoTeamPlay(Hand.paper);
        }
    }

    void DoTeamPlay(Hand hand)
    {   
        int winCount = 0;
        int loseCount = 0;
        for(int i=0; i<pcs.Length; i++)
        {
            pcs[i] = GetRandomPcHand();
            GameResult curResult = StartGame(hand, pcs[i]);
            if(curResult == GameResult.Win) winCount++;
            if(curResult == GameResult.Lose) loseCount++;
        }
        Debug.Log("총 "+pcs.Length+"번의 게임에서 "+winCount+"번 이겼습니다.");
        Debug.Log(loseCount+"번 졌습니다.");


    //foreach 연습
        // foreach(Hand h in pcs)
        // {
        //     Debug.Log(GetHandText(h));
        // }

    // goto 연습
        // foreach(var h in pcs)
        // {
        //     if(h == Hand.scissor) goto SCISSOR;
        // }

        // SCISSOR :
        // Debug.Log("가위");
    }

    Hand GetRandomPcHand()
    {
        return (Hand)Random.Range(0, (int)Hand.Max);
    }

    GameResult StartGame(Hand playerHand, Hand pcHand)
    {
        // pc = (Hand)Random.Range(0, (int)Hand.Max);
        player = playerHand;

        Debug.Log("나는 <" + GetHandText(playerHand) + "> 를 냈다.");
        Debug.Log("컴퓨터는 <" + GetHandText(pcHand) + "> 를 냈다.");

        GameResult result;
        if(pcHand == playerHand)
        {
            result = GameResult.Draw;
        }
        else if((pcHand == Hand.scissor) && (playerHand == Hand.rock)
            || (pcHand == Hand.rock) && (playerHand == Hand.paper) 
            || (pcHand == Hand.paper) && (playerHand == Hand.scissor))
        {
            result = GameResult.Win;
        }
        else
        {
            result = GameResult.Lose;
        }

        ShowResult(result);
        return result;
    }

    void ShowResult(GameResult result)
    {
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
