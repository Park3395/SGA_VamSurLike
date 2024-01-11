using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 카메라 위치 오브젝트
    [SerializeField]
    Transform Pos;

    // 플레이어 오브젝트
    [SerializeField]
    Transform Target;

    void Update()
    {
        this.transform.LookAt(Target);
        this.transform.position = Pos.position;
    }
}
