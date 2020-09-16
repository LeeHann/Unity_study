using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;
    bool isStepped = false;

    private void OnEnable() {
        isStepped = false;
        
        for(int i=0; i<obstacles.Length; i++)
        {
            if(Random.Range(0, 3) == 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "Player" && !isStepped)
        {
            isStepped = true;
            GameManager.instance.AddScore(1);
        }
    }
}
