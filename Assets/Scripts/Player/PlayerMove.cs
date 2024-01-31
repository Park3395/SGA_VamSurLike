using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

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
    // �̵� �˻�
    bool onMove = false;


    // ������
    [SerializeField]
    Transform aim;
    // �÷��̾� ����ġ
    [SerializeField]
    Transform focus;
    // ���� �÷��̾� ����
    [SerializeField]
    Transform front;

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

        if(h != 0 || v != 0)
        {
            //Quaternion rot = Quaternion.identity; // Quaternion ���� ������ ���� ���� �� �ʱ�ȭ

            //rot.eulerAngles = new Vector3(0, Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg, 0); // ���� eulerAngles�� �̿��� ���Ϸ� ������ Quaternion���� ����


            //transform.rotation = rot; // �� ������ ȸ��

            Vector3 nowF = front.position - focus.position;
            nowF.Normalize();
            Vector3 toF = aim.position - focus.position;
            toF.Normalize();

            nowF.y = 0;
            toF.y = 0;
            float angle = Vector3.SignedAngle(nowF, toF, this.transform.up);

            Vector3 rot = Vector3.positiveInfinity;
            rot = Vector3.RotateTowards(nowF, toF, 360f, Time.deltaTime * PlayerStat.instance.Speed);
            
            transform.eulerAngles = rot;
        }


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
