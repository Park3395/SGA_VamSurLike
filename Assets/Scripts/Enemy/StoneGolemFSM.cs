using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class StoneGolemFSM : MonoBehaviour, IHitEnemy
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


    // HP �����̴�
    [SerializeField] private Slider hpSlider;
    [SerializeField] private float HP = 480;
    [SerializeField] private float MaxHP = 480;
    public int attackPower = 20;
    public int Exp = 0;

    // �⺻ ���� ����
    [SerializeField] private float attackDistance = 6.0f;

    // ������ ���� ����
    [SerializeField] private float skillDistance = 20.0f;
    [SerializeField] private float skillDelay = 10.0f;
    [SerializeField] private float skillTimer;

    // laser 
    [SerializeField] private float initialLaserDuration = 3.0f;
    [SerializeField] private float fixedLaserDuration = 1.0f;
    bool laserCanAttack;

    Animator anim;

    // �÷��̾��� ��ġ
    Transform player;

    // �÷��̾� ����
    PlayerStat pStat;

    // ������̼� �޽� ������Ʈ
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        // �ʱ� ���� : ����
        e_State = StoneGolemState.Spawn;

        // �÷��̾� ��ġ ��ǥ ��������
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // �÷��̾� ���� ��������
        pStat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStat>();

        // �ڽ� ������Ʈ�� �ִϸ����� ������Ʈ ��������
        anim = GetComponent<Animator>();

        // ������̼� ������Ʈ ������Ʈ ��������
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // ��ų ��Ÿ�� (�������� �ƴ� ��)
        if (e_State != StoneGolemState.Spawn)
        {
            if (skillTimer >= 0)
                skillTimer -= Time.deltaTime;
        }

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
        // StoneGolem�� �÷��̾ �ٶ󺸵��� ����
        transform.forward = player.position;
        // ���� �ִϸ��̼��� ������ ���� �� �÷��̾ �����ϵ��� 2.0���� ���ð��� ���� �ڷ�ƾ�Լ� ���.
        StartCoroutine(SpawnToRun());
    }

    IEnumerator SpawnToRun()
    {
        yield return new WaitForSeconds(2.0f);
        e_State = StoneGolemState.Run;
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

            anim.SetTrigger("SpawnToRun");
        }
        // �÷��̾���� �Ÿ��� ���� ��Ÿ� �̳����
        else if (Vector3.Distance(transform.position, player.position) <= attackDistance)
        {
            // enum���� ���¸� Attack���� ��ȯ
            Debug.Log("Attack");
            e_State = StoneGolemState.Attack;
        }
        // �÷��̾���� �Ÿ��� ��ų ��Ÿ� �̳��̰�, ��ų ��Ÿ���� 0�̶��
        if (Vector3.Distance(transform.position, player.position) <= skillDistance && skillTimer < 0.0f)
        {
            e_State = StoneGolemState.Skill;
            skillTimer = skillDelay;
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

    // ������ ó�� �Լ�
    public void HitEnemy(float hitPower)
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

        // �� ü���� 0���� ũ�ų� ���������� ���°� �ƴ� �� �ǰ� ���·� ��ȯ
        if (HP > 0 || e_State != StoneGolemState.Skill)
        {
            e_State = StoneGolemState.Hurt;

            // �ǰ� �ִϸ��̼� ���
            anim.SetTrigger("Hurt");
            Hurt();
        }
        // �׷��� ������ ��� ���·� ��ȯ
        else if (HP <= 0)
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
        // Laser animation ���
        anim.Play("LaserAiming");
        StartCoroutine(ActivateLaser());
    }

    // ������ ��ų //
    IEnumerator ActivateLaser()
    {
        laserCanAttack = false;
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
            laserCanAttack = true;
            anim.SetTrigger("LaserAttack");
            // player�� ������ ��ġ�� ����
            lR.SetPosition(1, mPos);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // �� �� �÷��̾ �������� ������ �������� ����
        // ������ ó�� �Լ�. 
        if (laserCanAttack == true && elapsedTime == fixedLaserDuration)
        {
            pStat.NowHP -= attackPower;
        }

        // ������ ��Ȱ��ȭ
        lR.enabled = false;
        laserCanAttack=false;

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
        // LineRenderer ������Ʈ�� �ڽİ�ü�� Inspector���� ã��.
        LineRenderer lR = GetComponentInChildren<LineRenderer>();
        lR.enabled = false;


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