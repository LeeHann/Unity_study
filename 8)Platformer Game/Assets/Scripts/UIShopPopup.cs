using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopPopup : MonoBehaviour
{
    [SerializeField] Text txtCoin;
    PlayerController player;
    void OnEnable()
    {
        player = FindObjectOfType<PlayerController>();

        ShowCoin(player.coin);
        player.UpdateCoinAction += ShowCoin;
    }

    private void OnDisable() {
        player.UpdateCoinAction -= ShowCoin; 
    }

    void ShowCoin(int coin)
    {
        txtCoin.text = coin.ToString();
    }
}
