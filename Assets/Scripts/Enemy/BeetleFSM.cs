using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BeetleFSM : MonoBehaviour, IHitEnemy
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
    [SerializeField] private float attackDistance = 2.0f;

    // HP �����̴�
    [SerializeField] private Slider hpSlider;

    // HP
    [SerializeField] private float HP = 80;
    [SerializeField] private float MaxHP = 80;

    // ���ݷ�
    public int AttackPower = 12;

    // ����ġ
    public int Exp = 0;
    public bool isDie;

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
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // �ִϸ����� ������Ʈ ��������
        anim = GetComponent<Animator>();

        // ������̼� ������Ʈ ������Ʈ ��������
        agent = GetComponent<NavMeshAgent>();

        isDie = false;
    }

    void OnEnable()
    {
        e_State = BeetleState.Spawn;
        HP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {

        // �÷��̾ �׾��ٸ� ����.
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            anim.enabled = false;
        }

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
                //Hurt();
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
        agent.isStopped = true;
        // beetle�� �÷��̾ �ٶ󺸵��� ����
        transform.forward = player.position;
        // ���� �ִϸ��̼��� ������ ���� �� �÷��̾ �����ϵ��� 4.0���� ���ð��� ���� �ڷ�ƾ�Լ� ���.
        StartCoroutine(SpawnToRun());
    }

    IEnumerator SpawnToRun()
    {
        yield return new WaitForSeconds(4.0f);
        // �÷��̾ �ν��� �� �ִ� �Ÿ� ���� ������
        if (Vector3.Distance(transform.position, player.position) >= attackDistance)
        {
            // enum������ ���¸� Run���� ��ȯ
            e_State = BeetleState.Run;
            // �̵� �ִϸ��̼� ��ȯ
            anim.SetTrigger("IdleToRun");
        }
    }

    // �̵� ����
    void Run()
    {
        // ���� ��ġ�� ���� ��Ÿ����� ũ�ٸ� �÷��̾ ���� �̵�
        if (Vector3.Distance(transform.position, player.position) >= attackDistance)
        {
            // ������Ʈ�� �̵��� �����ϰ� ��θ� �ʱ�ȭ
            agent.isStopped = true;
            agent.ResetPath();

            // ������̼����� �����ϴ� �ּ� �Ÿ��� ���� ������ �Ÿ��� ����
            agent.stoppingDistance = attackDistance;

            // ������̼��� �������� �÷��̾��� ��ġ�� ����
            agent.destination = player.position;
        }
        // �÷��̾���� �Ÿ��� ���� ��Ÿ� �̳����
        else
        {
            // ������Ʈ�� �̵��� ����.
            agent.isStopped = true;

            // enum���� ���¸� Attack���� ��ȯ
            e_State = BeetleState.Attack;
        }
    }

    // ���� ����
    void Attack()
    {
        Debug.Log("Attack");
        // �÷��̾ ���� ���� ����� ������ �����Ѵ�
        if (Vector3.Distance(transform.position, player.position) <= attackDistance)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                anim.Play("Attack");
            }
        }
        // ���� ������ ����ٸ� ���� ���¸� Run���� ��ȯ�Ѵ� (���߰�)
        else
        {
            // �ִϸ��̼��� ���ᰡ �Ǿ��ٸ�
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                e_State = BeetleState.Run;
                anim.SetTrigger("AttackToRun");
            }
        }
    }

    // ������ ó�� �Լ�
    public void HitEnemy(float hitPower)
    {
        // ����, �ǰ�, ��� ������ ��쿡�� �Լ� ��� ����
        if (e_State == BeetleState.Spawn || e_State == BeetleState.Death)
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
            e_State = BeetleState.Hurt;

            // �ǰ� �ִϸ��̼� ���
            anim.SetTrigger("Hurt");
            Hurt();
        }
        // �׷��� ������ ��� ���·� ��ȯ
        else
        {
            e_State = BeetleState.Death;

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
        agent.isStopped = true;
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
