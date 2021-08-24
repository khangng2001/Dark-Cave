using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private void Awake() {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void WalkAnimation(int walk){
        animator.SetInteger(TagManager.WALK_ANIMATION, walk);
    }
    public void JumpAnimation(bool jump){
        animator.SetBool(TagManager.JUMP_ANIMATION, jump);
    }
    public void SetFacingDirection(int facingDir){
        if(facingDir >0)
            spriteRenderer.flipX = false;
        else if(facingDir<0)
            spriteRenderer.flipX = true;
        
    }
}
