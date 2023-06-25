using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5;
    float hAxis;
    float vAxis;
    Vector3 moveVec;
    Camera viewCamera;


    void Start()
    {
    
        viewCamera = Camera.main;
    }
    void Update()
    {
        GetInput();
        Move();
        Turn();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += moveVec * moveSpeed * Time.deltaTime;
        
    }
    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }

    
}
