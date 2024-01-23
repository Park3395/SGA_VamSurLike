using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 플레이어 스텟
    PlayerStat pStat;
    // 캐릭터 컨트롤러
    CharacterController cc;
    // 점프 상태 검사
    int jumpingCount = 0;
    // 현재 점프력
    float yVelocity = 0;

    // 조준점
    [SerializeField]
    Transform aim;
    // 플레이어 정위치
    [SerializeField]
    Transform focus;

    Animator anim;
    void Start()
    {
        // 전역 변수 초기화
        pStat = this.GetComponent<PlayerStat>();
        cc = this.GetComponent<CharacterController>();
        anim = this.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // 플레이어 이동
        #region move
        
        // 키보드 수평 이동 입력
        float h = Input.GetAxis("Horizontal");
        // 키보드 수직 이동 입력
        float v = Input.GetAxis("Vertical");

        // 플레이어 이동을 위한 벡터 설정 및 정규화
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;
        playRun(dir);

        // 플레이어 이동 방향을 카메라가 보는 방향으로 설정
        dir = Camera.main.transform.TransformDirection(dir);
        dir *= pStat.Speed * Time.deltaTime;
        #endregion

        // 플레이어 점프
        #region jump

        // 플레이어가 땅에 닿았을 때
        if (cc.collisionFlags == CollisionFlags.Below)
        {
            // 점프 중이었다면
            if (jumpingCount != pStat.JumpCount)
            {
                // 점프가 아닌 상태로 전환
                jumpingCount = pStat.JumpCount;

                anim.SetBool("Jumping", false);
            }
            
            // 점프력 초기화
            yVelocity = 0;
        }

        // 점프 버튼 (space)가 입력되었을 때 player의 점프 횟수가 남았다면
        if (Input.GetButtonDown("Jump") && jumpingCount != 0)
        {
            // 저장된 점프력만큼 점프력 설정
            yVelocity = pStat.Jump;

            anim.SetBool("Jumping",true);

            // 점프 횟수 1회 차감
            jumpingCount--;
        }

        // 점프력에 중력값 적용
        yVelocity += pStat.Gravity * Time.deltaTime;
        // 플레이어 이동 벡터에 점프 값 적용
        dir.y = yVelocity;

        #endregion

        // 플레이어 이동 처리
        cc.Move(dir);

        #region rotate

        Vector3 fromX = new Vector3(focus.position.x, 0, focus.position.z);
        Vector3 toX = new Vector3(aim.position.x, 0, aim.position.z);
        float angleX = Vector3.SignedAngle(fromX, toX, this.transform.up);

        #endregion
    }

    void playRun(Vector3 dir)
    {
        if (Mathf.Approximately(dir.x, 0) && Mathf.Approximately(dir.z, 0))
        {
            anim.SetBool("isMove", false);
        }
        else
        {
            anim.SetBool("isMove", true);
        }
        anim.SetFloat("xDir",dir.x);
        anim.SetFloat("yDir", dir.z);
    }
}
