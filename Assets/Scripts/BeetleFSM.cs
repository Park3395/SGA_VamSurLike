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

    public float findDistance = 10.0f;

    public float attackDistance = 2.0f;

    public float HP = 80;
    public float MaxHP = 80;
    public float AttackPower = 12;

    Animator anim;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        e_State = BeetleState.Spawn;

        player = GameObject.Find("Player").transform;

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
        transform.forward = player.position;
        StartCoroutine(SpawnToRun());
        if (Vector3.Distance(transform.position, player.position) < findDistance)
        {
            e_State = BeetleState.Run;
            anim.SetTrigger("IdleToRun");
        }
    }

    IEnumerator SpawnToRun()
    {
        yield return new WaitForSeconds(4.0f);
    }

    void Run()
    {
        if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            Debug.Log("Run");
            //�̵� ����
            Vector3 dir = (player.position - transform.position).normalized;

            //�÷��̾ ���� ���� ��ȯ
            transform.forward = dir;
        }
        else if (Vector3.Distance(transform.position, player.position) <= attackDistance)
        {
            Debug.Log("Attack");
            e_State = BeetleState.Attack;
        }
    }
    void Attack()
    {
        // �÷��̾ ���� ���� ����� ������ �����Ѵ�
        if (Vector3.Distance(transform.position, player.position) <= attackDistance)
        {
            anim.Play("Attack");
        }
        // ���� ������ ����ٸ� ���� ���¸� Move�� ��ȯ�Ѵ� (���߰�)
        else
        {
            e_State = BeetleState.Run;
            anim.SetTrigger("AttackToRun");
        }
    }

    public void AttackAction()
    {
        //player.GetComponent<PlayerMove>().DamageAction(attackPower);
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

    void Die()
    {
        // ���� ���� �ǰ� �ڷ�ƾ �Լ��� �����Ѵ�
        StopAllCoroutines();

        // ��� ���¸� ó���ϱ� ���� �ڷ�ƾ�� �����Ѵ�
        StartCoroutine(DieProcess());
    }

    // ��� ���� ó���� �ڷ�ƾ
    IEnumerator DieProcess()
    {

        // 2�� ���� ��ٸ� ���� �ڱ��ڽ��� �����Ѵ�
        yield return new WaitForSeconds(2.0f);
        print("�Ҹ�!");
        Destroy(gameObject);
    }
}
