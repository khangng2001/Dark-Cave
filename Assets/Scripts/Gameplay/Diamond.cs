using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    
    void Start()
    {
        Door.instance.RegisterDiamond();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(TagManager.PLAYER_TAG)){
            SoundController.instance.CollectableSound();
            Door.instance.DiamondCollected();
            Destroy(gameObject);
        }
    }
}
