using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // 플레이어의 Transform을 참조할 변수
    public Vector3 offset; // 카메라와 플레이어 사이의 거리를 조절할 오프셋

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset; // 카메라 위치를 플레이어 위치 + 오프셋으로 설정
        
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
