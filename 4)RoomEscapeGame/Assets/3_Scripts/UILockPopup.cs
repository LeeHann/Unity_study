using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILockPopup : MonoBehaviour
{
    // 자물쇠 팝업 : 잠김 또는 잠김해제 상태를 텍스트로 보여줌, 버튼을 맞는 패스워드로 맞추면 잠김 해제

    public Text txtLockState;
    public Image[] imgLockButtons; // 버튼 이미지 교체
    public Sprite[] colorButtonSprites;

    CombiLock combiLock;
    CombiLock.LockButton[] password;
    CombiLock.LockButton[] curButtons;

    public void InitPopup(CombiLock combiLock, CombiLock.LockButton[] pw)
    {
        this.combiLock = combiLock;
        password = pw;
        txtLockState.text = "잠금";
        
        curButtons = new CombiLock.LockButton[pw.Length];

        for(int i=0; i<curButtons.Length; i++)
        {
            curButtons[i] = CombiLock.LockButton.Red;
            int ci = (int)curButtons[i];
            imgLockButtons[i].sprite = colorButtonSprites[ci];
        }
    }

    public void ClickLockButton(int index)
    {
        int nextColor = ((int)curButtons[index] + 1)  % (int)CombiLock.LockButton.Max;
        curButtons[index] = (CombiLock.LockButton)nextColor; // enum

        imgLockButtons[index].sprite = colorButtonSprites[nextColor];

        // 패스워드 체크
        int check = 0;
        for(int i=0; i<curButtons.Length; i++)
        {
            if(curButtons[i] == password[i])
            {
                check++;
            }
        }
        if (check == password.Length)
        {
            txtLockState.text = "잠금 해제";
            combiLock.Unlock();
        }
    }
}
