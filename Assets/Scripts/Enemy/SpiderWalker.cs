using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalker : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private Transform groundCheckPos;
    private RaycastHit2D groundHit;
    private bool moveLeft;
    [SerializeField]
    private float moveSpeed = 5f;
    private Vector3 temPos,temScale;
    private float scaleXValue;
    private float maxWalkDistanceValue = 10f;
    private float minX, maxX;

    private void Awake() {
        sprite = GetComponent<SpriteRenderer>();
        // groundCheckPos = GameObject.Find("Ground Check Position").transform;
        groundCheckPos = transform.GetChild(0);
        moveLeft = Random.Range(0, 2) > 0 ? true : false;
        scaleXValue = transform.localScale.x;
        minX = transform.position.x - maxWalkDistanceValue;
        maxX = transform.position.x + maxWalkDistanceValue;
    }
    private void Update() {
         HandleWalkingWithGroundCheck();
         CheckGround();
       // HandleWalkingWithWalkDistance();
    }
     void CheckGround()
    {
        groundHit = Physics2D.Raycast(groundCheckPos.position, Vector2.down,0.1f,groundLayer);
        if(!groundHit)
            moveLeft = !moveLeft;
    }
    
    void HandleWalkingWithGroundCheck(){
        temPos = transform.position;
        temScale = transform.localScale;
        if(moveLeft){
            temPos.x -= moveSpeed * Time.deltaTime;
            temScale.x = -scaleXValue;
        }else{
            temPos.x += moveSpeed * Time.deltaTime;
            temScale.x = scaleXValue;
        }
        transform.position = temPos;
        transform.localScale = temScale;
    }
    void HandleWalkingWithWalkDistance(){
        temPos = transform.position;
        if(moveLeft){
            temPos.x -= moveSpeed * Time.deltaTime;
        }else{
            temPos.x += moveSpeed * Time.deltaTime;
        }
        transform.position = temPos;
        sprite.flipX = moveLeft;
        if(temPos.x<minX)
            moveLeft = false;
        else if(temPos.x>maxX)
            moveLeft = true;
    }
}
