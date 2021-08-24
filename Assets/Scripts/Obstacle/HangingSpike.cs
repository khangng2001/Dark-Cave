using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingSpike : MonoBehaviour
{
    [SerializeField]
    private LayerMask playerLayer;
    private RaycastHit2D playerHit2D;
    private bool playerDetected;
    private Rigidbody2D spikeBody;
    private void Awake() {
        spikeBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        DetectPlayer();
    }
    void DetectPlayer(){
        if(playerDetected)
            return;
        playerHit2D = Physics2D.Raycast(transform.position, Vector2.down, 10f, playerLayer);
        if(playerHit2D){
            playerDetected = true;
            Invoke("DeactiveGameObject", 3f);
            spikeBody.gravityScale = 1f;
        }
    }

    void DeactiveGameObject(){
        gameObject.SetActive(false);
    }
    // private void OnTriggerEnter2D(Collider2D other) {
    //     if(other.CompareTag(TagManager.PLAYER_TAG)){
    //         GameplayController.instance.GameOver(false);
    //     }
    // }

}
