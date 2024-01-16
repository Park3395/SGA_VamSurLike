using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 카메라 시점 오브젝트
    [SerializeField]
    Transform Target;

    void Update()
    {
        // 카메라 시점을 Target으로 초기화
        this.transform.LookAt(Target);
    }
}
