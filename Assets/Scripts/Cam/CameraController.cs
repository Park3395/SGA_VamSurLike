using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 카메라 시점 오브젝트
    [SerializeField]
    Transform Target;
    [SerializeField]
    Transform Player;

    [SerializeField]
    float dis = 7.0f;

    private void Awake()
    {
    }

    void Update()
    {
        Vector3 dir = Player.position - Target.position;
        dir.Normalize();

        dir = Quaternion.AngleAxis(30f,dir) * dir * dis;
        Debug.Log(dir);

        Vector3 move = Target.position + dir;
        
        this.transform.position = move;
        
        // 카메라 시점을 Target으로 초기화
        this.transform.LookAt(Target);
    }
}
