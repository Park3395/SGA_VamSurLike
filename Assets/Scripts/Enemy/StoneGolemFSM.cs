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

    public bool isDie;
    public int Exp = 0;

    // �⺻ ���� ����
    [SerializeField] private float attackDistance = 6.0f;

    // ������ ��Ÿ��
    [SerializeField] private float skillDelay = 10.0f;
    [SerializeField] private float skillTimer;

    // laser 
    [SerializeField] private Transform laserOrigin;
    LineRenderer laserLine;
    public float aimDuration = 3.0f;
    public float laserRange = 50.0f;
    // ���� �� ������ �÷��̾� ��ġ
    bool isAiming;
    public GameObject laserFactory;
    public float laserSpeed = 5.0f;

    Animator anim;

    // �÷��̾��� ��ġ
    Transform player;

    // �÷��̾� ����
    PlayerStat pStat;

    // ������̼� �޽� ������Ʈ
    NavMeshAgent agent;

    int enumerCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // �ʱ� ���� : ����
        e_State = StoneGolemState.Spawn;

        // �÷��̾� ��ġ ��ǥ ��������
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // �÷��̾� ���� ��������
        pStat = PlayerStat.instance;

        // �ڽ� ������Ʈ�� �ִϸ����� ������Ʈ ��������
        anim = GetComponent<Animator>();

        // ������̼� ������Ʈ ������Ʈ ��������
        agent = GetComponent<NavMeshAgent>();

        // ������
        laserLine = GetComponentInChildren<LineRenderer>();

        isDie = false;
        skillTimer = skillDelay;
    }

    void OnEnable()
    {
        isDie = false;
        e_State = StoneGolemState.Spawn;
        HP = MaxHP;
        skillTimer = skillDelay;
    }

    // Update is called once per frame
    void Update()
    {
        // ��ų ��Ÿ�� (�������� �ƴ� ��)
        
        if (skillTimer >= 0)
            skillTimer -= Time.deltaTime;

        //Debug.Log("skillTimer" + skillTimer);

        // �÷��̾ �׾��ٸ� ����.
        if ( GameObject.FindGameObjectWithTag("Player") == null)
        {
            anim.enabled = false;
            agent.isStopped = true;
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
        agent.isStopped = true;
        // StoneGolem�� �÷��̾ �ٶ󺸵��� ����
        transform.forward = player.position;
        // ���� �ִϸ��̼��� ���� �� Run���� ��ȯ
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            e_State = StoneGolemState.Run;
        }
    }

    // �̵� ����
    void Run()
    {
        anim.SetTrigger("SpawnToRun");
        if (skillTimer <0.0f && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            isAiming = true;
            e_State = StoneGolemState.Skill;
        }
        else
        {
            if (Vector3.Distance(transform.position, player.position) >= attackDistance)
            {

                agent.isStopped = true;
                agent.ResetPath();

                // ������̼����� �����ϴ� �ּ� �Ÿ��� ���� ������ �Ÿ��� ����
                agent.stoppingDistance = attackDistance;

                // ������̼��� �������� �÷��̾��� ��ġ�� ����
                agent.destination = player.position;

            }
            // �÷��̾���� �Ÿ��� ���� ��Ÿ� �̳���, ��ų�� ��Ÿ���̶��
            else
            {
                // enum���� ���¸� Attack���� ��ȯ
                Debug.Log("Attack");
                e_State = StoneGolemState.Attack;
            }
        }
    }

    // ���� ����
    void Attack()
    {
        // �÷��̾ ���� ���� ����� ������ �����Ѵ�
        if (Vector3.Distance(transform.position, player.position) <= attackDistance)
        {
            agent.isStopped = true;
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
        if (e_State == StoneGolemState.Spawn || e_State == StoneGolemState.Skill || e_State == StoneGolemState.Death)
        {
            return;
        }

        // �÷��̾��� ���ݷ¸�ŭ �� ü�� ����.
        HP -= hitPower;

        // ������Ʈ�� �̵��� �����ϰ� ��θ� �ʱ�ȭ
        agent.isStopped = true;
        agent.ResetPath();

        // �� ü���� 0���� ũ�ų� ���������� ���°� �ƴ� �� �ǰ� ���·� ��ȯ
        if (HP > 0)
        {
            // ��ų�� ������� �ƴ� ��
            e_State = StoneGolemState.Hurt;

            // �ǰ� �ִϸ��̼� ���
            anim.SetTrigger("Hurt");
            Hurt();
        }
        // �׷��� ������ ��� ���·� ��ȯ
        else
        {
            e_State = StoneGolemState.Death;
            Die();
        }
    }

    // ������ ��ų
    void Skill()
    {
        agent.isStopped = true;
        // Laser animation ���
        anim.Play("LaserAiming");
        if (isAiming)
        {
            // �������� ���� ��ġ ���� �� laserOrigin
            laserLine.SetPosition(0, laserOrigin.position);

            // ��� �ð�
            float elapsedTime = 0f;

            while (elapsedTime <= aimDuration)
            {
                // �÷��̾���� ���� ����
                laserLine.SetPosition(1, player.position);
                elapsedTime += Time.deltaTime;
            }
        }
        
        StartCoroutine(ActivateLaser());
    }

    // ������ ��ų //
    IEnumerator ActivateLaser()
    {
        if (enumerCount == 0)
        {
            enumerCount = 1;
            laserLine.enabled = true;
            yield return new WaitForSeconds(aimDuration);
            laserLine.enabled = false;
            isAiming = false;
            anim.SetTrigger("LaserAttack");

            GameObject laser = Instantiate(laserFactory);
            laser.transform.position = laserOrigin.transform.position;
            Rigidbody rb = laser.GetComponent<Rigidbody>();
            Vector3 playerPos = player.transform.position;
            Vector3 laserPos = laser.transform.position;
            laser.transform.forward = playerPos;
            rb.AddForce((playerPos - laserPos).normalized * laserSpeed, ForceMode.Impulse);

            // enum ���¸� Run���� ��ȯ
            e_State = StoneGolemState.Run;
            // ��Ÿ��
            skillTimer = skillDelay;
            anim.SetTrigger("SkillToRun");

            enumerCount = 0;
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
        e_State = StoneGolemState.Run;
    }

    void Die()
    {

        isDie = true;
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
        gameObject.SetActive(false);
    }
}