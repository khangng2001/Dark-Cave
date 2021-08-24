using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour     
{
    [SerializeField]
    private float moveSpeed=6f, jumpForce= 10f;
    private Rigidbody2D playerBody;
    private Vector3 temPos;
    private PlayerAnimation playerAnimation;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private Transform groundCheckPos;
    private BoxCollider2D boxCollider2D;
    void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

   private void Update() {
        //HandleMovementWithTransform();
        HandlePlayerAnimation();
        HandleJumping();
    }
    private void FixedUpdate() {
        HandleMovementWithRigidBody();
    }
   private void HandleMovementWithTransform(){
        temPos = transform.position;
        if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {
            temPos.x -= moveSpeed * Time.deltaTime;
        }else if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
            temPos.x += moveSpeed * Time.deltaTime;
        }
        transform.position = temPos;
    }
    private void HandleMovementWithRigidBody(){
        if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {
            playerBody.velocity = new Vector2(-moveSpeed, playerBody.velocity.y);
            //playerBody.AddForce(new Vector2(-moveSpeed, 0f),ForceMode2D.Impulse);
           // playerAnimation.SetFacingDirection(-1);
        }
        else if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {              
            playerBody.velocity = new Vector2(moveSpeed, playerBody.velocity.y);
            //playerAnimation.SetFacingDirection(1);
        }
        else
         playerBody.velocity = new Vector2(playerBody.velocity.x, playerBody.velocity.y);
    }
    private  void HandlePlayerAnimation(){
        playerAnimation.WalkAnimation((int)Mathf.Abs(playerBody.velocity.x));
        playerAnimation.SetFacingDirection((int)playerBody.velocity.x);
        playerAnimation.JumpAnimation(!IsGround());
    }
    private bool IsGround(){
        // Debug.DrawRay(groundCheckPos.position, Vector2.down * 0.1f, Color.green);
        // return Physics2D.Raycast(groundCheckPos.position, Vector2.down, 0.1f, groundLayer);
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down,0.1f,groundLayer);
    }

    private void HandleJumping(){
        
        if(Input.GetButtonDown(TagManager.JUMP_BUTTON)){
                SoundController.instance.PlayerJumpSound();
                if(IsGround()){
                playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);
                }
       } 
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag==TagManager.ENEMY_TAG)
            {
                SoundController.instance.GameOverSound();
                GameplayController.instance.GameOver(false);
            }
        else if(other.tag==TagManager.GOAL_TAG)  
            GameplayController.instance.GameOver(true);  
    }   

    private void OnCollisionEnter2D(Collision2D other) {
         if(other.gameObject.tag==TagManager.ENEMY_TAG)
            {
                 SoundController.instance.GameOverSound();
                GameplayController.instance.GameOver(false); 
            }
    } 
   
}
