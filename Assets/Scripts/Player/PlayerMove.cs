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

    // ȭ�� ȸ�� ��
    float mx = 0;
    // ���� ������
    float yVelocity = 0;

    void Start()
    {
        // ���� ���� �ʱ�ȭ
        pStat = this.GetComponent<PlayerStat>();
        cc = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        // �÷��̾� �̵�
        #region move
        
        // Ű���� ���� �̵� �Է�
        float h = Input.GetAxis("Horizontal");
        // Ű���� ���� �̵� �Է�
        float v = Input.GetAxis("Vertical");

        // �÷��̾� �̵��� ���� ���� ���� �� ����ȭ
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        // �÷��̾� �̵� ������ ī�޶� ���� �������� ����
        dir = Camera.main.transform.TransformDirection(dir);
        dir *= pStat.Speed * Time.deltaTime;
        #endregion

        // �÷��̾� ����
        #region jump

        // �÷��̾ ���� ����� ��
        if (cc.collisionFlags == CollisionFlags.Below)
        {
            // ���� ���̾��ٸ�
            if (jumpingCount != pStat.JumpCount)
                // ������ �ƴ� ���·� ��ȯ
                jumpingCount = pStat.JumpCount;
            
            // ������ �ʱ�ȭ
            yVelocity = 0;
        }

        // ���� ��ư (space)�� �ԷµǾ��� �� player�� ���� Ƚ���� ���Ҵٸ�
        if (Input.GetButtonDown("Jump") && jumpingCount != 0)
        {
            // ����� �����¸�ŭ ������ ����
            yVelocity = pStat.Jump;
            // ���� Ƚ�� 1ȸ ����
            jumpingCount--;
        }

        // �����¿� �߷°� ����
        
        yVelocity += pStat.Gravity * Time.deltaTime;
        // �÷��̾� �̵� ���Ϳ� ���� �� ����
        dir.y = yVelocity;

        #endregion

        // �÷��̾� �̵� ó��
        cc.Move(dir);

        #region rotate
        
        // ���콺 ���� �Է�
        float mouseX = Input.GetAxis("Mouse X");

        // ���� �Է°� ����� ȸ�� �ӵ� ���� ó��
        mx += mouseX * pStat.RotSpeed * Time.deltaTime;
        // �÷��̾� ���� ȸ��
        transform.eulerAngles = new Vector3(0, mx, 0);

        #endregion
    }
}
