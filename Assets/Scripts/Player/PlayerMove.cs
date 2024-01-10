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

    // 카메라 회전 속도
    [SerializeField]
    float rotSpeed = 200f;

    float mx = 0;

    void Start()
    {
        pStat = this.GetComponent<PlayerStat>();
        cc = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        // 플레이어 이동
        #region move

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float yVelocity = 0;

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        dir = Camera.main.transform.TransformDirection(dir);

        #endregion

        // 플레이어 점프
        #region jump

        if (cc.collisionFlags == CollisionFlags.Below)
        {
            // 점프 중이라면?
            if (jumpingCount != pStat.JumpCount)
                // 점프 중일 때 점프 전 상태로 초기화한다
                jumpingCount = pStat.JumpCount;
            
            yVelocity = 0;
        }

        if (Input.GetButtonDown("Jump") && jumpingCount != 0)
        {
            yVelocity = pStat.Jump;
            jumpingCount--;
        }

        yVelocity += pStat.Gravity * Time.deltaTime;
        dir.y = yVelocity;

        #endregion

        cc.Move(dir * pStat.Speed * Time.deltaTime);

        #region rotate

        float mouseX = Input.GetAxis("Mouse X");

        mx += mouseX * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, mx, 0);

        #endregion
    }
}
