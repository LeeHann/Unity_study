using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] AudioClip deathClip; // 사망시 재생할 오디오 클립
    public float jumpForce = 700f;

    private int jumpCount = 0; // 이단 점프를 제한하는 변수
    private bool isGround = false;
    private bool isDead = false; // 생사 여부

    Rigidbody2D rigidbody;
    Animator animator;
    AudioSource audio;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    private void Update() {
        if(isDead) return;

        if(Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            //Jump
            jumpCount++;

            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(new Vector2(0f, jumpForce));
            audio.Play();
        }
        else if(Input.GetMouseButtonUp(0) && rigidbody.velocity.y > 0)
        {
            rigidbody.velocity *= 0.5f;
        }

        animator.SetBool("isGround", isGround);
    }

    private void Die()
    {
        animator.SetTrigger("Die");

        audio.clip = deathClip;
        audio.Play();

        rigidbody.velocity = Vector2.zero;

        isDead = true;

        GameManager.instance.OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Dead" && !isDead)
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.contacts[0].normal.y > 0.7f) // 닿는 물체 중 첫번째 물체의 방향벡터 (크기가 1인 단위벡터)
        {
            isGround = true;
            jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        isGround = false;
    }
}
