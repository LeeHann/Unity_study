using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // delegate

// delegate : 메소드를 변수처럼 담아올 수 있게 하는 것

// [System.Serializable] // 구조체 등 선언 위에 작성 시 변수를 에디터 상에서 드러내게 함
// public class PlayerInfo : UnityEvent<int>  // * 이벤트 제어 클래스
// {

// }



public class PlayerController : MonoBehaviour
{
    // delegate
    // public UnityAction<int> UpdateN;
    // public UnityEvent<int, string> OnUpdate; // event/update 앞은 on을 자주 쓴다.
    // public UnityEvent OnUpdate; // * 에디터 상에서 이벤트 제어 가능
    // public PlayerInfo CoinEvent; // * 클래스를 사용하여 에디터 상에서 이벤트 제어
    public delegate void UpdateNumberInfoAction(int a);
    public event UpdateNumberInfoAction UpdateHpAction;
    public event UpdateNumberInfoAction UpdateCoinAction;


    //property
    public int hp
    {
        get; private set;
    }

    public int coin
    {
        get; private set;
    }


    // editor managing
    [SerializeField] int maxHp = 3;

    [SerializeField] float speed = 1f;
    [SerializeField] float jumpingPower = 5f;
    [SerializeField] int jumpableCount = 1;

    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer renderer;
    CapsuleCollider2D collider;
    Rigidbody2D rigidbody;
    
    bool isJumping = false;
    int jumpCount = 0;

    Vector3 startPos;
    
    bool isDead = false; // hp 1개 없어지는 죽음
    bool isReallyDead = false; // hp가 0이 되었을 때 죽음


    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
        startPos = transform.position;
        // hp, coin 초기화
        UpdateHp(maxHp);
        coin = 0;
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

    public void GetCoin(int addCoin)
    {
        coin += addCoin;

        if(UpdateCoinAction != null) UpdateCoinAction(coin);
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
        collider.enabled = false;
        renderer.sortingLayerName = "DeadPlayer";
        yield return new WaitForSeconds(1.5f);
        
        if(hp > 0)
        {
            // 부활
            isDead = false;
            transform.position = startPos;
            collider.enabled = true;
            renderer.sortingLayerName = "Player";
            rigidbody.velocity = Vector2.zero;
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
