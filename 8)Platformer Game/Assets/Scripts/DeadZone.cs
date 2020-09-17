using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(TilemapCollider2D))]

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        PlayerController player = other.transform.GetComponent<PlayerController>();
        
        if(player != null)
        {
            player.OnDead();
        }    
    }
}
