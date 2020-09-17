using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// delegate : 메소드를 변수처럼 담아올 수 있게 하는 것

public class PlayerController : MonoBehaviour
{
    public delegate void UpdateNumberInfoAction(int a);

    public UnityAction<int> UpdateHpAction;

    public int hp
    {
        get; private set;
    }
    [SerializeField] int maxHp = 3;

    [SerializeField] float speed = 1f;
    [SerializeField] float jumpingPower = 5f;
    [SerializeField] int jumpableCount = 1;

    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer renderer;
    Rigidbody2D rigidbody;
    
    bool isJumping = false;
    int jumpCount = 0;

    Vector3 startPos;
    
    bool isDead = false; // hp 1개 없어지는 죽음
    bool isReallyDead = false; // hp가 0이 되었을 때 죽음


    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        UpdateHp(maxHp);
    }

    private void Update() {
        if(isDead || isReallyDead) return;

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
        if(isDead || isReallyDead) return;

        Move();
        Jump();
    }

    public void UpdateHp(int addHp)
    {
        hp += addHp;
        if(hp > maxHp) hp = maxHp;
        if(hp < 0) hp = 0;

        if(UpdateHpAction != null) UpdateHpAction(hp);
    }

    public void OnDead()
    {
        if(isDead) return;
        StartCoroutine(IEDead());
    }

    IEnumerator IEDead()
    {
        isDead = true;

        UpdateHp(-1);
        animator.SetBool("isDead", isDead);
        
        rigidbody.velocity = Vector2.zero;
        rigidbody.AddForce(new Vector2(1f, 10f), ForceMode2D.Impulse);

        yield return new WaitForSeconds(1.5f);
        
        if(hp > 0)
        {
            // 부활
            isDead = false;
            transform.position = startPos;
            animator.SetBool("isDead", isDead);
        }
        else{
            isReallyDead = true;
        }
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
