using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bullet;

    void Start()
    {
        bullet = GetComponent<Rigidbody>();
        //탄알의 속도 = 앞 쪽 방향 * 이동 속력
        bullet.velocity = transform.forward * speed;

        //3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            
            if(player != null)
            {
                player.Die();
            }
        }    
    }

    void Update()
    {
        
    }
}
