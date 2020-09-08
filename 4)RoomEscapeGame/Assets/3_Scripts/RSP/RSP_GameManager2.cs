using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RSP_GameManager2 : MonoBehaviour
{
    /*
    * 가위바위보 게임
        1. 내 손 버튼을 누르면 PC의 손이 랜덤하게 정해지고,
        2. 내가 낸 손 모양이랑 PC의 손 모양의 승패를 갈라서 결과를 텍스트로 보여줌. 
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
        Win,
        Lose,
        Draw
    }

    public Image imgPcHand;
    public Sprite[] handSprites;
    public Text txtGameResult;
    public Color[] gameResultTextColors;
    public Text txtAllResult;
    
    int allGame, allWin, allLose;

    Hand[] pcHandPattern = new Hand[10];
    int teamAllGame, teamAllWin, teamAllLose;
    public Color[] gameTeamResultBgColors;
    public Image gameBackground;

    private void Start() {
        allGame = 0;
        allWin = 0;
        allLose = 0;
        txtGameResult.text = "";

        teamAllGame = 0;
        teamAllWin = 0;
        teamAllLose = 0;
    }

    public void ClickMyHandButton(int handInt)
    {
        allGame++;

        Hand myHand = (Hand)handInt;

        // Hand pcHand = (Hand)Random.Range(0, (int)Hand.Max);
        int pcHandInt = Random.Range(0, (int)Hand.Max);
        Hand pcHand = (Hand)pcHandInt;

        imgPcHand.sprite = handSprites[pcHandInt];

        WinOrLose(handInt, pcHandInt, false);
       /* 
        // 승패 체크 (+무승부)
        GameResult result;
        if (handInt == pcHandInt)
        {
            // 무승부
            txtGameResult.text = "비겼다.";
            // txtGameResult.color = gameResultTextColors[2];
            result = GameResult.Draw;
        }
        else if ((myHand == Hand.Rock && pcHand == Hand.Scissors)
               ||(myHand == Hand.Scissors && pcHand == Hand.Paper) 
               ||(myHand == Hand.Paper && pcHand == Hand.Rock))
        {
            // 승리
            allWin++;
            txtGameResult.text = "이겼다!!!";
            // txtGameResult.color = gameResultTextColors[0];
            result = GameResult.Win;
        }
        else
        {
            // 패배
            allLose++;
            txtGameResult.text = "졌다...";
            // txtGameResult.color = gameResultTextColors[1];
            result = GameResult.Lose;
        }
        txtGameResult.color = gameResultTextColors[(int)result];
        */

        string resultText = "총 {0} 회 대결\n<size=40><color=#FF698F>{1} 회 승</color> / {2} 회 패</size>";
        txtAllResult.text = string.Format(resultText, allGame, allWin, allLose);
    }

    public void ClickTeam(int myHandInt)
    {
        //단체전
        for(int i =0; i<10; i++)
        {
            teamAllGame++;
            pcHandPattern[i] = (Hand)Random.Range(0, (int)Hand.Max);
            imgPcHand.sprite = handSprites[(int)pcHandPattern[i]];
            WinOrLose(myHandInt, (int)pcHandPattern[i], true);
            Debug.Log(pcHandPattern[i]);
            string resultText = "단체전 총 {0} 회 대결\n<size=40><color=#FF698F>{1} 회 승</color> / {2} 회 패</size>";
            txtAllResult.text = string.Format(resultText, teamAllGame, teamAllWin, teamAllLose);
        }

        if(teamAllWin > teamAllLose)
        {
            gameBackground.color = gameTeamResultBgColors[0];
            txtGameResult.text = "이겼다!!!";
        }
        else if(teamAllWin < teamAllLose)
        {
            gameBackground.color = gameTeamResultBgColors[1];
            txtGameResult.text = "졌다...";
        }
        else if(teamAllWin == teamAllLose)
        {
            gameBackground.color = gameTeamResultBgColors[2];
            txtGameResult.text = "비겼다.";
        }
    }

    public void WinOrLose(int handInt, int pcHandInt, bool isTeam)
    {
        GameResult result;
        Hand myHand = (Hand)handInt;
        Hand pcHand = (Hand)pcHandInt;

        if (handInt == pcHandInt)
        {
            // 무승부
            txtGameResult.text = "비겼다.";
            // txtGameResult.color = gameResultTextColors[2];
            result = GameResult.Draw;
        }
        else if ((myHand == Hand.Rock && pcHand == Hand.Scissors)
               ||(myHand == Hand.Scissors && pcHand == Hand.Paper) 
               ||(myHand == Hand.Paper && pcHand == Hand.Rock))
        {
            // 승리
            if(isTeam) teamAllWin++;
            else allWin++; 
            txtGameResult.text = "이겼다!!!";
            // txtGameResult.color = gameResultTextColors[0];
            result = GameResult.Win;
        }
        else
        {
            // 패배
            if(isTeam) teamAllLose++;
            else allLose++;
            txtGameResult.text = "졌다...";
            // txtGameResult.color = gameResultTextColors[1];
            result = GameResult.Lose;
        }
        txtGameResult.color = gameResultTextColors[(int)result];
    }

    public void ClickReset()
    {
        allGame = 0;
        allWin = 0;
        allLose = 0;
        txtGameResult.text = "";

        teamAllGame = 0;
        teamAllWin = 0;
        teamAllLose = 0;

        string resultText = "총 {0} 회 대결\n<size=40><color=#FF698F>{1} 회 승</color> / {2} 회 패</size>";
        txtAllResult.text = string.Format(resultText, allGame, allWin, allLose);

        gameBackground.color = gameTeamResultBgColors[3];
    }
}
