using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleFSM : MonoBehaviour
{
    private enum BeetleState
    {
        Spawn,
        Run,
        Attack,
        Hurt,
        Death
    }

    BeetleState e_State;

    public float findDistance = 5;

    public float attackDistance = 0.01f;

    CharacterController cc;

    Animator anim;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        e_State = BeetleState.Spawn;

        player = GameObject.Find("Player").transform;

        cc = GetComponent<CharacterController>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���¸� �˻��ϰ� ���º��� ������ ����� �����Ѵ�
        switch (e_State)
        {
            case BeetleState.Spawn:
                Spawn();
                break;
            case BeetleState.Run:
                Run();
                break;
            case BeetleState.Attack:
                Attack();
                break;
            case BeetleState.Hurt:
                Hurt();
                break;
            case BeetleState.Death:
                //Damaged();
                break;
        }
    }

    void Spawn()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Spawn") && Vector3.Distance(transform.position, player.position) < findDistance)
        {
            e_State = BeetleState.Run;

            anim.SetTrigger("IdleToRun");
        }
    }

    void Run()
    {
        if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            ////�̵� ����
            //Vector3 dir = (player.position - transform.position).normalized;

            ////ĳ���� ��Ʈ�ѷ��� ����Ͽ� �̵�
            //cc.Move(dir * Time.deltaTime);

            ////�÷��̾ ���� ���� ��ȯ
            //transform.forward = dir;
        }
    }
        void Attack()
    {

    }

    // �ǰ� ����
    void Hurt()
    {
        // �ǰ� ���¸� ó���ϴ� �ڷ�ƾ �Լ��� ȣ���Ѵ�
        StartCoroutine(DamageProcess());
    }

    // �ǰ� ���� ó���� �ڷ�ƾ
    IEnumerator DamageProcess()
    {
        // �ǰ� �ִϸ��̼� ��� �ð���ŭ ��ٸ���
        yield return new WaitForSeconds(1.0f);

        // ���� ���¸� �̵����� ��ȯ�Ѵ�
        e_State = BeetleState.Run;
    }
}
