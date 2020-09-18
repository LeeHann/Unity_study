using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue;

    private void OnTriggerEnter2D(Collider2D other) {
        PlayerController player = other.transform.GetComponent<PlayerController>();
        
        if(player != null)
        {
            player.GetCoin(coinValue);
            Destroy(gameObject);
        }
    }
}
