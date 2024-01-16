using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGolemFSM : MonoBehaviour
{
    private enum StoneGolemState
    {
        Spawn,
        Run,
        Attack,
        Skill,
        Hurt,
        Death
    }

    StoneGolemState e_State;

    public float findDistance = 10.0f;

    public float attackDistance = 2.0f;

    public float HP = 480;
    public float MaxHP = 480;
    public float AttackPower = 20;
    public float AttackDelay = 1.0f;
    public float SkillDelay = 5.0f;

    Animator anim;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        e_State = StoneGolemState.Spawn;

        player = GameObject.Find("Player").transform;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���¸� �˻��ϰ� ���º��� ������ ����� �����Ѵ�
        switch (e_State)
        {
            case StoneGolemState.Spawn:
                Spawn();
                break;
            case StoneGolemState.Run:
                Run();
                break;
            case StoneGolemState.Attack:
                Attack();
                break;
            case StoneGolemState.Skill:
                Skill();
                break;
            case StoneGolemState.Hurt:
                Hurt();
                break;
            case StoneGolemState.Death:
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
            e_State = StoneGolemState.Run;
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
            e_State = StoneGolemState.Attack;
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
            e_State = StoneGolemState.Run;
            anim.SetTrigger("AttackToRun");
        }
    }

    public void AttackAction()
    {
        //player.GetComponent<PlayerMove>().DamageAction(attackPower);
    }

    // ������ ��ų
    void Skill()
    {
        StartCoroutine(LaserAttack());   
    }

    IEnumerator LaserAttack()
    {
        yield return new WaitForSeconds(3.0f);
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
        e_State = StoneGolemState.Run;
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