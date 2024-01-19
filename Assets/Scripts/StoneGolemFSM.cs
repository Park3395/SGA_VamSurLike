using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

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

    // ���� ��Ÿ�
    public float findDistance = 40.0f;
    // �⺻ ���� ����
    public float attackDistance = 6.0f;
    // ������ ���� ����
    public float skillDistance = 20.0f;

    public float HP = 480;
    public float MaxHP = 480;
    public float AttackPower = 20;
    public float AttackDelay = 1.0f;

    // laser 
    public float initialLaserDuration = 3.0f;
    public float fixedLaserDuration = 1.0f;

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
        e_State = StoneGolemState.Spawn;

        // �÷��̾� ��ġ ��ǥ ��������
        player = GameObject.Find("Player").transform;

        // �ڽ� ������Ʈ�� �ִϸ����� ������Ʈ ��������
        anim = GetComponent<Animator>();

        // ������̼� ������Ʈ ������Ʈ ��������
        agent = GetComponent<NavMeshAgent>();
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
                //Hurt();
                break;
            case StoneGolemState.Death:
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
            e_State = StoneGolemState.Skill;
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
            Vector3 dir = (player.position - transform.position).normalized;

            transform.forward = dir;

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
            e_State = StoneGolemState.Attack;
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
        // ���� ������ ����ٸ� ���� ���¸� Run���� ��ȯ�Ѵ� (���߰�)
        else
        {
            e_State = StoneGolemState.Run;
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
        if (e_State == StoneGolemState.Spawn || e_State == StoneGolemState.Hurt || e_State == StoneGolemState.Death)
        {
            return;
        }

        // �÷��̾��� ���ݷ¸�ŭ �� ü�� ����.
        HP -= hitPower;

        // ������Ʈ�� �̵��� �����ϰ� ��θ� �ʱ�ȭ
        agent.isStopped = true;
        agent.ResetPath();

        // �� ü���� 0���� ũ�� �ǰ� ���·� ��ȯ
        if (HP > 0)
        {
            e_State = StoneGolemState.Hurt;

            // �ǰ� �ִϸ��̼� ���
            anim.SetTrigger("Hurt");
            Hurt();
        }
        // �׷��� ������ ��� ���·� ��ȯ
        else
        {
            e_State = StoneGolemState.Death;

            // ��� �ִϸ��̼� ���
            anim.SetTrigger("Death");
            Die();
        }
    }

    // ������ ��ų
    void Skill()
    {
        if (Vector3.Distance(transform.position, player.position) <= skillDistance)
        {
            // Laser animation ���
            anim.Play("LaserAiming");
            StartCoroutine(ActivateLaser());
        }
        else
        {
            e_State = StoneGolemState.Run;
        }
    }

    IEnumerator ActivateLaser()
    {
        // LineRenderer ������Ʈ�� �ڽİ�ü�� Inspector���� ã��.
        LineRenderer lR = GetComponentInChildren<LineRenderer>();
        lR.enabled = true;

        // LineRenderer�� ��ġ ����
        lR.positionCount = 2;

        // ???? mdlGolem���� child�� MuzzleLaser�� ��ġ �޾ƿ���.
        lR.SetPosition(0, GameObject.FindGameObjectWithTag("LaserPos").transform.position);
        // ��� �ð�
        float elapsedTime = 0f;

        // ��� �ð��� �ʱ� ������ ���� �ð�(3��)�� �� ������ ����
        while (elapsedTime < initialLaserDuration)
        {
            lR.SetPosition(1, player.position);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // �÷��̾��� ������ ��ġ�� ����
        Vector3 mPos = player.position;
        elapsedTime = 0f;
        // 1�� ���� �������� �������� ���� �� �ִ� ����
        while (elapsedTime < fixedLaserDuration)
        {
            anim.SetTrigger("LaserAttack");
            // player�� ������ ��ġ�� ����
            lR.SetPosition(1, mPos);
            elapsedTime += Time.deltaTime;
            // �� �� �÷��̾ �������� ������ �������� ����
            /*
            // ������ ó�� �Լ�. 


             */
            yield return null;
        }

        // ������ ��Ȱ��ȭ
        lR.enabled = false;

        // ������ �߻� �� 1�� ���
        yield return new WaitForSeconds(1.0f);

        // enum ���¸� Run���� ��ȯ
        e_State = StoneGolemState.Run;
        anim.SetTrigger("SkillToRun");
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
        anim.Play("Death");

        // 2�� ���� ��ٸ� ���� �ڱ��ڽ��� �����Ѵ�
        yield return new WaitForSeconds(2.0f);
        print("�Ҹ�!");
        Destroy(gameObject);
    }
}