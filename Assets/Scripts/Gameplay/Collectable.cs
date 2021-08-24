using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    
    private enum typeCollectable { timeCollectable, airCollectable };
    [SerializeField]
    private typeCollectable type;
    private float collectableValueMax = 10f;
    private float collectableValueMin = 3f;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag==TagManager.PLAYER_TAG){
            SoundController.instance.CollectableSound();
            if(type==typeCollectable.timeCollectable){
                GameplayController.instance.IncreaseTime(Random.Range(collectableValueMin,collectableValueMax));
                gameObject.SetActive(false);
            }
            else if(type==typeCollectable.airCollectable)
            {
                SoundController.instance.CollectableSound();
                GameplayController.instance.IncreaseAir(Random.Range(collectableValueMin,collectableValueMax));
                gameObject.SetActive(false);
            }
        }
    }
}
