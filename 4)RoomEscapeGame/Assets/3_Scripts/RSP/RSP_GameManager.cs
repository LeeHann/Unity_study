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
        1. Hand[] pcHandPattern 배열을 만들고, 10개의 준비된 손 모양을 차례로 내기.
        2. 단체전 버튼(가위,바위,보)을 추가하고, 한번 누르면 10번의 대결 결과를 보여주기.
        3. 배경 이미지를 만들고, 단체전 승패에 따라 배경색 바꾸기.
        4. 지금까지 대결 결과 리셋 버튼 만들기. 
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

    public const int NUM_OF_GROUP_GAME = 10;
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

    public Image imgBG;     
    public Color winBgColor;
    public Color loseBgColor;
    public Image imgPcHand;
    public Sprite[] handSprites;
    public Text txtGameResult;
    public Color[] gameResultTextColors;
    public Text txtAllResult;
    
    int allGame, allWin, allLose;

    private void Start() {
        ClickReset();    
    }

    public void ClickReset()
    {
        allGame = 0;
        allWin = 0;
        allLose = 0;
        txtGameResult.text = "";
        txtAllResult.text = "";
    }

    IEnumerator IEShowGroupResult(int myHandInt)
    {
        int groupWin = 0;
        int groupLose = 0;
        Hand myHand = (Hand)myHandInt;
        for(int i=0; i<NUM_OF_GROUP_GAME; i++)
        {
            int pcHandIndex = (int)pcHandPattern[i];
            imgPcHand.sprite = handSprites[pcHandIndex];
                    
            GameResult result = GetGameResult(myHand, pcHandPattern[i]);
            switch(result)
            {
                case GameResult.Win :
                    groupWin += 1;
                    txtGameResult.text = (i+1) + "번째 대결은 이겼다.";
                    break;
                case GameResult.Lose :
                    groupLose += 1;
                    txtGameResult.text = (i+1) + "번째 대결은 졌다.";
                    break;
                case GameResult.Draw :
                    txtGameResult.text = (i+1) + "번째 대결은 비겼다.";
                    break;
            }
            yield return new WaitForSeconds(0.5f);
        }

        if (groupWin > groupLose)
        {
            txtGameResult.text = "단체전 이겼다!!!";
            txtGameResult.color = gameResultTextColors[0];
            imgBG.color = winBgColor;
        }
        else
        {
            txtGameResult.text = "단체전 졌다...";
            txtGameResult.color = gameResultTextColors[1];
            imgBG.color = loseBgColor;
        }

        string resultText = "단체전 ({0} 회 대결)\n<size=40><color=#FF698F>{1} 회 승</color> / {2} 회 패</size>";
        txtAllResult.text = string.Format(resultText, NUM_OF_GROUP_GAME, groupWin, groupLose);
        
    }

    IEnumerator ShowGroupGameResultCoroutine;
    public void ClickGroupGame(int myHandInt)
    {
        // StartCoroutine("IEShowGroupResult", myHandInt); // string 오타 발생으로 인한 오류 가능성
        
        // StartCoroutine(IEShowGroupResult(myHandInt)); // Stop 불가

        ShowGroupGameResultCoroutine = IEShowGroupResult(myHandInt);
        StartCoroutine(ShowGroupGameResultCoroutine);
        
        // StopCoroutine(ShowGroupGameResultCoroutine);
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
                txtGameResult.text = "이겼다!!!";
                break;

            case GameResult.Lose :
                allLose += 1;
                txtGameResult.text = "졌다...";
                break;

            case GameResult.Draw :
                txtGameResult.text = "비겼다.";
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