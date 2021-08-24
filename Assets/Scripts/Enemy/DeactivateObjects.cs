    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObjects : MonoBehaviour
{
    private float deactivateTimer = 3f;
    private void OnEnable() {
        Invoke("DeactivateGameObjects", deactivateTimer);
    }
    private void OnDisable() {
        CancelInvoke("DeactivateGameObjects");
    }
    void DeactivateGameObjects(){
        if(gameObject.activeInHierarchy){
            CancelInvoke("DeactivateGameObjects");
            gameObject.SetActive(false);
        }
    }
}
