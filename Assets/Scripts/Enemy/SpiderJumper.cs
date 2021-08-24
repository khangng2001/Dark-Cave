using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour
{
    private Rigidbody2D enemyBody;
    private float minJumpForce=5f, maxJumpForce=10f;
    private Animator anim;
    private float minWaitTime = 1.5f, maxWaitTime = 3.5f;
    private float jumpTimer;
    private bool canJump;

    private void Awake() {
        enemyBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Start() {
        jumpTimer = Random.Range(minWaitTime, maxWaitTime)+Time.time;
    }
    private void Update() {
        // Debug.Log(enemyBody.velocity.magnitude);
        HandleJumping();
        HandleAnimation();
    }
    void HandleJumping(){
        if(Time.time>jumpTimer){
            jumpTimer = Random.Range(minWaitTime, maxWaitTime)+Time.time;
            Jump();
        }
        if(enemyBody.velocity.magnitude==0){
            canJump = true;
        }
    }
    void Jump(){
        if(canJump){
            SoundController.instance.SpiderJumperSound();
            canJump = false;
            enemyBody.velocity = new Vector2(enemyBody.velocity.x, Random.Range(minJumpForce, maxJumpForce));
        }
    } 
    void HandleAnimation(){
        if(enemyBody.velocity.magnitude==0)
            anim.SetBool(TagManager.JUMP_ANIMATION, false);
        else
            anim.SetBool(TagManager.JUMP_ANIMATION, true);
    }
}
