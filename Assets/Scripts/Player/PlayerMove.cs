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
    int jumpingCount = 0;

    // ī�޶� ȸ�� �ӵ�
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
        // �÷��̾� �̵�
        #region move

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float yVelocity = 0;

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        dir = Camera.main.transform.TransformDirection(dir);

        #endregion

        // �÷��̾� ����
        #region jump

        if (cc.collisionFlags == CollisionFlags.Below)
        {
            // ���� ���̶��?
            if (jumpingCount != pStat.JumpCount)
                // ���� ���� �� ���� �� ���·� �ʱ�ȭ�Ѵ�
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
