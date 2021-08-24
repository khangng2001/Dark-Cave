using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static Door instance;
    private BoxCollider2D box;
    private Animator animator;
    private int diamondCount;
    private void Awake() {
        if(instance==null)
            instance = this;
        box = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }
    private void OpenDoor(){
        animator.Play(TagManager.DOOR_ANIMATION);
    }
    private void RemoveCollider(){
        box.enabled = false;
    }
    public void RegisterDiamond(){
        diamondCount++;
        // 
    }
    public void DiamondCollected(){
        diamondCount--;
        if(diamondCount==0){
            OpenDoor();
        }
    }
}
