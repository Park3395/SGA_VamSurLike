using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �÷��̾� ����
    PlayerStat pStat;
    // ĳ���� ��Ʈ�ѷ�
    CharacterController cc;

    // ���� ���� �˻�
    bool isJumping = false;

    void Start()
    {
        pStat = this.GetComponent<PlayerStat>();
    }

    void Update()
    {
        // �÷��̾� �̵�
        #region move
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        dir = Camera.main.transform.TransformDirection(dir);

        cc.Move(dir * pStat.Speed * Time.deltaTime);
        #endregion

        // �÷��̾� ����
        #region jump
        if (Input.GetButtonDown("Jump")&& !isJumping)
        {
            dir.y = pStat.Jump * Time.deltaTime;
            isJumping = true;
        }
        #endregion

    }
}
