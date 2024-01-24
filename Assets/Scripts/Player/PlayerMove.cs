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
    // ���� ������
    float yVelocity = 0;

    // ������
    [SerializeField]
    Transform aim;
    // �÷��̾� ����ġ
    [SerializeField]
    Transform focus;

    Animator anim;
    void Start()
    {
        // ���� ���� �ʱ�ȭ
        pStat = this.GetComponent<PlayerStat>();
        cc = this.GetComponent<CharacterController>();
        anim = this.GetComponentInChildren<Animator>();
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
        playRun(dir);

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
            {
                // ������ �ƴ� ���·� ��ȯ
                jumpingCount = pStat.JumpCount;

                anim.SetBool("Jumping", false);
            }
            
            // ������ �ʱ�ȭ
            yVelocity = 0;
        }

        // ���� ��ư (space)�� �ԷµǾ��� �� player�� ���� Ƚ���� ���Ҵٸ�
        if (Input.GetButtonDown("Jump") && jumpingCount != 0)
        {
            // ����� �����¸�ŭ ������ ����
            yVelocity = pStat.Jump;

            anim.SetBool("Jumping",true);

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
