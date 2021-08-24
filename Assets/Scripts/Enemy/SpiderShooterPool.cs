using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooterPool : MonoBehaviour
{
    [SerializeField]
    private GameObject spiderBullet;
    [SerializeField]
    private Transform bulletSpawnPos;
    private float minSpawnTime = 1f, maxSpawnTime = 3f;
    private float waitTime;
    private List<GameObject> bullets = new List<GameObject>();
    private int initialBullets = 20;

    private void Awake() {
        CreateInitialBullets();
    }
    private void Start() {
        waitTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);

    }
    private void Update() {
        if(Time.time>waitTime){
            waitTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
            Shoot();
        }
    }
    private void CreateInitialBullets()
    {
        for (int i = 0; i < initialBullets; i++)
        {
            GameObject newBullets = Instantiate(spiderBullet);
            newBullets.SetActive(false);
            newBullets.transform.SetParent(transform);
            bullets.Add(newBullets);
        }
    }
    void Shoot(){
        // for (int i = 0; i < bullets.Count; i++)
        // {
        //     if(!bullets[i].activeInHierarchy){
        //         bullets[i].SetActive(true);
        //         bullets[i].transform.position = bulletSpawnPos.transform.position;
        //         break;
        //     }
        // }
        foreach(GameObject bullet in bullets){
            if(!bullet.activeInHierarchy){
                bullet.SetActive(true);
                bullet.transform.position = bulletSpawnPos.transform.position;
                break;
            }
        }
    }
}
