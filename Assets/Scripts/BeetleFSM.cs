using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BeetleFSM : MonoBehaviour
{
    // ���¸� ��Ÿ���� enum ����
    private enum BeetleState
    {
        Spawn,
        Run,
        Attack,
        Hurt,
        Death
    }

    BeetleState e_State;

    // �÷��̾ �����ϴ� �νİŸ�
    public float findDistance = 10.0f;
    // �÷��̾ �����ϴ� �νİŸ�
    public float attackDistance = 2.0f;

    // HP
    public float HP = 80;
    public float MaxHP = 80;
    // ���ݷ�
    public float AttackPower = 12;

    // HP �����̴�
    public Slider hpSlider;

    Animator anim;

    // �÷��̾��� ��ġ
    Transform player;

    // ������̼� �޽� ������Ʈ
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        // �ʱ� ���� : ����
        e_State = BeetleState.Spawn;

        // �÷��̾� ��ġ ��ǥ ��������
        player = GameObject.Find("Player").transform;

        // �ڽ� ������Ʈ�� �ִϸ����� ������Ʈ ��������
        anim = transform.GetComponentInChildren<Animator>();

        // ������̼� ������Ʈ ������Ʈ ��������
        agent = GetComponent<NavMeshAgent>();
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

        // ���� HP�� �����̴��� �ݿ�
        hpSlider.value = (float)HP / (float)MaxHP;
    }

    // ���� ����
    void Spawn()
    {
        // beetle�� �÷��̾ �ٶ󺸵��� ����
        transform.forward = player.position;
        // ���� �ִϸ��̼��� ������ ���� �� �÷��̾ �����ϵ��� 4.0���� ���ð��� ���� �ڷ�ƾ�Լ� ���.
        StartCoroutine(SpawnToRun());
        // �÷��̾ �ν��� �� �ִ� �Ÿ� ���� ������
        if (Vector3.Distance(transform.position, player.position) < findDistance)
        {
            // enum������ ���¸� Run���� ��ȯ
            e_State = BeetleState.Run;
            // �̵� �ִϸ��̼� ��ȯ
            anim.SetTrigger("IdleToRun");
        }
    }

    IEnumerator SpawnToRun()
    {
        yield return new WaitForSeconds(4.0f);
    }

    // �̵� ����
    void Run()
    {
        // ���� ��ġ�� ���� ��Ÿ����� ũ�ٸ� �÷��̾ ���� �̵�
        if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            //Debug.Log("Run");
            ////�̵� ����
            //Vector3 dir = (player.position - transform.position).normalized;

            ////�÷��̾ ���� ���� ��ȯ
            //transform.forward = dir;

            // ������Ʈ�� �̵��� �����ϰ� ��θ� �ʱ�ȭ
            agent.isStopped = true;
            agent.ResetPath();

            // ������̼����� �����ϴ� �ּ� �Ÿ��� ���� ������ �Ÿ��� ����
            agent.stoppingDistance = attackDistance;

            // ������̼��� �������� �÷��̾��� ��ġ�� ����
            agent.destination = player.position;
        }
        // �÷��̾���� �Ÿ��� ���� ��Ÿ� �̳����
        else if (Vector3.Distance(transform.position, player.position) <= attackDistance)
        {
            // enum���� ���¸� Attack���� ��ȯ
            Debug.Log("Attack");
            e_State = BeetleState.Attack;
        }
    }

    // ���� ����
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

    // �÷��̾��� ������ ó�� �Լ�
    public void AttackAction()
    {
        //player.GetComponent<PlayerMove>().DamageAction(attackPower);
    }

    // ������ ó�� �Լ�
    public void HitEnemy(int hitPower)
    {
        // ����, �ǰ�, ��� ������ ��쿡�� �Լ� ��� ����
        if (e_State == BeetleState.Spawn || e_State == BeetleState.Hurt || e_State == BeetleState.Death)
        {
            return;
        }

        // �÷��̾��� ���ݷ¸�ŭ �� ü�� ����.
        HP -= hitPower;

        // �� ü���� 0���� ũ�� �ǰ� ���·� ��ȯ
        if (HP > 0)
        {
            e_State = BeetleState.Hurt;

            // �ǰ� �ִϸ��̼� ���
            anim.SetTrigger("Hurt");
            Hurt();
        }
        // �׷��� ������ ��� ���·� ��ȯ
        else
        {
            e_State = BeetleState.Death;

            // ��� �ִϸ��̼� ���
            anim.SetTrigger("Death");
            Die();
        }
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
