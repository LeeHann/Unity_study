using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float jumpingPower = 5f;
    [SerializeField] int jumpableCount = 1;

    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer renderer;
    Rigidbody2D rigidbody;
    
    bool isJumping = false;
    int jumpCount = 0;
    
    bool isDead = false;


    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(isDead) return;

        float xAxis = Input.GetAxis("Horizontal");
        if(xAxis > 0.1 || xAxis < -0.1) 
        {
            animator.SetBool("isWalk", true);
            if(xAxis > 0) renderer.flipX = false; //right
            else renderer.flipX = true;
        }
        else 
        {
            animator.SetBool("isWalk", false);
        }
    }

    private void FixedUpdate() {
        if(isDead) return;
        
        Move();
        Jump();
    }

    public void OnDead()
    {
        isDead = true;

        animator.SetBool("isDead", isDead);
    }
    
    void Move()
    {
        float xVelocity = 0f;
        float xAxis = Input.GetAxis("Horizontal");
        
        if(xAxis < -0.1f) // left
        {
            xVelocity = -1f;
        }
        else if(xAxis > 0.1f)
        {
            xVelocity = 1f;    
        }

        rigidbody.velocity = new Vector2(xVelocity * speed, rigidbody.velocity.y);
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && jumpCount < jumpableCount)
        {
            isJumping = true;
            jumpCount++;

            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(new Vector2(0f, jumpingPower), ForceMode2D.Impulse);

            animator.SetBool("isJump", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.contacts[0].normal.y > 0f)
        {
            isJumping = false;
            jumpCount = 0;
            animator.SetBool("isJump", false);
        }
    }

}
