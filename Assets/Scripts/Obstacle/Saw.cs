using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    private float moveSpeed = 5f;
    private Transform targetPos;
    [SerializeField]
    private Transform movePoint_1, movePoint_2;
    private bool firstMovePoint;
    private float rotationSpeed = 200f;
    private Vector3 temRotation = Vector3.zero;
    private float zAngle;

    private void Awake()
    {
        if (Random.Range(0, 2) > 0)
        {
            firstMovePoint = false;
            targetPos = movePoint_2;
            rotationSpeed *= -1f;
        }
        else
        {
            firstMovePoint = true;
            targetPos = movePoint_1;
        }
    }

    private void Update()
    {
        HandleMoveMent();
        HandleRotation();
    }
    void HandleMoveMent(){
        transform.position = Vector3.MoveTowards(transform.position, targetPos.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position,targetPos.position)<0.1f){
            if(firstMovePoint){
                firstMovePoint = false;
                targetPos = movePoint_2;
            }else{
                firstMovePoint = true;
                targetPos = movePoint_1;
            }
        }
    }
    void HandleRotation(){
        zAngle += Time.deltaTime*rotationSpeed;
        //transform.localEulerAngles = new Vector3(0f, 0f, zAngle);
        temRotation.z = zAngle;
        transform.Rotate(temRotation);
    }
}





















