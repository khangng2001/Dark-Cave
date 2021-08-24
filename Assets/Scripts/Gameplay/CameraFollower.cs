using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private Transform target;
    private Vector3 camPos;
    private float offSetX = 3f;
    private float minY;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.Find(TagManager.PLAYER_TAG).transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target==null)
            return;
        camPos = transform.position;
        camPos.x = target.position.x;
        transform.position = camPos;

    }
}
