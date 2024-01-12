using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamPosition : MonoBehaviour
{
    // 카메라 타겟 오브젝트
    [SerializeField]
    Transform Target;

    // 타겟과 카메라 기본 위치 사이의 거리
    float dis;

    private void Start()
    {
        // 거리 초기화
        dis = Vector3.Distance(this.transform.position, Target.position);
    }

    private void Update()
    {
        // 레이캐스트 방향 설정을 위한 forward 벡터 초기화
        this.transform.LookAt(Target);

        // 레이캐스트 실행 (카메라 타겟에서 카메라 위치 방향으로 설정)
        RaycastHit hit;
        Physics.Raycast(Target.transform.position, -this.transform.forward, out hit, dis);

        // 레이캐스트에 충돌 객체가 있는 경우 충돌 위치로 카메라 이동
        if(hit.point != Vector3.zero)
        {
            Camera.main.transform.position = hit.point;
        }
        // 없는 경우 카메라 기본 위치로 카메라 이동
        else
        {
            Camera.main.transform.position = this.transform.position;
        }

        /// add) 카메라의 미세한 벽뚫림 조절
    }
}
