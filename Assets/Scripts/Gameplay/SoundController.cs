using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;
    [SerializeField]
    private AudioClip playerJumpSound,gameOverSound,spiderJumperSound,collectableSound;
    private void Awake() {
        if(instance==null)
            instance = this;
    }
    public void PlayerJumpSound(){
        AudioSource.PlayClipAtPoint(playerJumpSound, transform.position);
    }

    public void GameOverSound(){
        AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
    }

     public void SpiderJumperSound(){
        AudioSource.PlayClipAtPoint(spiderJumperSound, transform.position);
    }

     public void CollectableSound(){
        AudioSource.PlayClipAtPoint(collectableSound, transform.position);
    }
    

}
