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
    float dis = 6.0f;

    Transform localtran;

    private void Awake()
    {
        localtran = Instantiate(Target,Target);
    }

    void Update()
    {
        localtran.SetLocalPositionAndRotation(new Vector3(0, -1, 0), Target.localRotation);

        Vector3 dir = Player.position - localtran.position;
        dir.Normalize();

        dir *= dis;

        Vector3 move = Target.position + dir;

        this.transform.position = move;
        
        // 카메라 시점을 Target으로 초기화
        this.transform.LookAt(Target);
        // 레이캐스트 실행 (카메라 타겟에서 카메라 위치 방향으로 설정)
        RaycastHit hit;
        Physics.Raycast(Target.transform.position, -this.transform.forward, out hit, dis);

        // 레이캐스트에 충돌 객체가 있는 경우 충돌 위치로 카메라 이동
        if (hit.point != Vector3.zero)
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
