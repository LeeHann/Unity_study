﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 유한 상태 머신 (AI)
    // Idle : 지정된 좌표를 서성거리면서 캐릭터가 근처에 왔는지 탐색
    // Follow : 캐릭터가 근처에 있으면 캐릭터를 향해 이동
    
    [SerializeField] Vector2 moveStartPos;
    [SerializeField] Vector2 moveEndPos;

    [SerializeField] float speed = 1f;
    [SerializeField] float idleTime = 0.5f;
    [SerializeField] float findTargetLength = 3f;
    float waitTime = 0f;
    bool isWaiting = false;

    [SerializeField] SpriteRenderer renderer;
    [SerializeField] Animator animator;

    private void Update() {
        if(FindPlayer() == true)
        {

        } else{
           OnIdle(); 
        }
    }

    bool FindPlayer()
    {
        Ray2D ray = new Ray2D(transform.position, GetDirection());
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, findTargetLength);

        if(hit.collider != null)
        {
            PlayerController player = hit.collider.GetComponent<PlayerController>();

            if(player != null)
            {
                OnFollow(player.transform.position);
                return true;
            }
        }
        return false;
    }

    void OnIdle()
    {
        if(isWaiting == false)
        {
            waitTime = 0f;
            Walk();
        }
        else
        {
            waitTime += Time.deltaTime;

            if(waitTime >= idleTime)
            {
                isWaiting = false;
                waitTime = 0;
            }
            animator.SetBool("isWalk", false);
        }
    }

    Vector2 GetDirection()
    {
        if(renderer.flipX == true)
            return Vector2.left;
        else
            return Vector2.right;
    }

    void Walk()
    {
        Vector2 dir = GetDirection();

        if(transform.position.x < moveStartPos.x)
        {
            isWaiting = true;
            dir = Vector2.right;
            renderer.flipX = false;
        } else if(transform.position.x > moveEndPos.x)
        {
            isWaiting = true;
            dir = Vector2.left;
            renderer.flipX = true;
        }

        transform.position += ((Vector3)dir * speed) * Time.deltaTime;
        animator.SetBool("isWalk", true);
    }

    void OnFollow(Vector3 targetPos)
    {
        Vector3 dir = (targetPos - transform.position).normalized;
        transform.position += (dir * speed) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        PlayerController player = other.GetComponent<PlayerController>();

        if(player != null)
        {
            player.OnDead();
        }
    }
}
