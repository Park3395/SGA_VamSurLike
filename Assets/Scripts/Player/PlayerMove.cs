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
    bool isJumping = false;

    void Start()
    {
        pStat = this.GetComponent<PlayerStat>();
    }

    void Update()
    {
        // 플레이어 이동
        #region move
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        dir = Camera.main.transform.TransformDirection(dir);

        cc.Move(dir * pStat.Speed * Time.deltaTime);
        #endregion

        // 플레이어 점프
        #region jump
        if (Input.GetButtonDown("Jump")&& !isJumping)
        {
            dir.y = pStat.Jump * Time.deltaTime;
            isJumping = true;
        }
        #endregion

    }
}
