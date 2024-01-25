using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VagrantFSM : MonoBehaviour
{
    public enum VagrantState
    {
        Spawn,
        Idle,
        Attack,
        Skill,
        Hurt,
        Death
    }

    VagrantState e_State;

    // Vagrant ����
    public float attackDistance = 60.0f;
    public int HP = 2100;
    public int MaxHP = 2100;
    public int attackPower = 10;
    public float speed = 1.0f;
    public float orbSpeed = 10.0f;
    public float attackDelay = 3;
    public float skillDelay = 10;
    private float attackTimer;
    private float skillTimer;

    // animator
    Animator anim;

    // player��ġ�� �޾ƿ� Transform
    Transform player;

    // ���� ����ü
    public GameObject OrbFactory;

    // ����ü�� �߻�� ��ġ
    [SerializeField]
    Transform missileLaunch;

    // ����ź�� �߻�� ��ġ
    [SerializeField]
    Transform trackingBomb;

    private void Start()
    {
        e_State = VagrantState.Spawn;

        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        attackTimer = attackDelay;
        skillTimer = skillDelay;
    }

    private void Update()
    {
        // Vagrant�� ���°� �������� �ƴҶ�
        if (e_State != VagrantState.Spawn)
        {
            // ���ݰ� ��ų�� ��Ÿ��
            if (attackTimer >= 0)
                attackTimer -= Time.deltaTime;
            if (skillTimer >= 0)
                skillTimer -= Time.deltaTime;
        }

        switch (e_State)
        {
            case VagrantState.Spawn:
                Spawn();
                break;
            case VagrantState.Idle:
                Idle();
                break;
            case VagrantState.Attack:
                Attack();
                break;
            case VagrantState.Skill:
                Skill();
                break;
            case VagrantState.Hurt:
                //Hurt();
                break;
            case VagrantState.Death:
                //Death();
                break;
        }
    }

    void Spawn()
    {
        StartCoroutine(SpawnAnimation());
        e_State = VagrantState.Idle;
    }

    IEnumerator SpawnAnimation()
    {
        yield return new WaitForSeconds(1.5f);
    }

    void Idle()
    {
        // �÷��̾�� ������ �Ÿ��� �����ǥ�迡�� ����ϱ� ���� y��ǥ�� 0�� ���ͻ���.
        Vector3 e_Pos = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 p_Pos = new Vector3(player.position.x, 0, player.position.z);
        transform.forward = p_Pos;

        // �÷��̾��� ��ġ�� ���� ���� ���̶�� �÷��̾ ���� �̵�
        if (Vector3.Distance(e_Pos, p_Pos) > attackDistance)
        {
            Vector3 dir = (p_Pos - e_Pos).normalized;
        }
        // �÷��̾��� ��ġ�� ���� ���� ���� �ְ�, ������ ������ �ð��� �Ǹ�
        if (Vector3.Distance(e_Pos, p_Pos) <= attackDistance && attackTimer < 0.0f)
        {
            // Attack���� ��ȯ
            e_State = VagrantState.Attack;
            attackTimer = attackDelay;
        }
        // �÷��̾��� ��ġ�� ���� ���� ���� �ְ�, skill(tracking bomb) �� �� �� �ִ� �ð��� �Ǹ�
        else if (Vector3.Distance(e_Pos, p_Pos) <= attackDistance && skillTimer < 0.0f)
        {
            // �ִϸ��̼� ���
            anim.SetTrigger("TrackingBomb");
            // Skill1�� ��ȯ
            e_State = VagrantState.Skill;
            skillTimer = skillDelay;
        }
    }

    void Attack()
    {
        StartCoroutine(ShootOrbs(0.5f));
        e_State = VagrantState.Idle;
    }

    IEnumerator ShootOrbs(float duration)
    {
        for (int i = 0; i < 6; i++)
        {
            Debug.Log("ShootOrbs");
            GameObject Orb = Instantiate(OrbFactory);
            Orb.transform.position = missileLaunch.position;
            Rigidbody rb = Orb.GetComponent<Rigidbody>();
            Vector3 playerPos = player.position;
            Vector3 OrbPos = Orb.transform.position;
            rb.AddForce((playerPos - OrbPos).normalized * orbSpeed, ForceMode.Impulse);
            yield return new WaitForSeconds(duration);
        }
    }

    void Skill()
    {
        // ���ǽ�
        // Tracking Bomb instantiate
        // Instantiate(Orb, trackingBomb.position, Quaternion.identity, transform);
        e_State = VagrantState.Idle;
        anim.SetTrigger("TrackingBombToIdle");
    }

    // ��� ����
    void Death()
    {
        // ���� ���� �ǰ� �ڷ�ƾ �Լ��� �����Ѵ�
        StopAllCoroutines();

        // ��� ���¸� ó���ϱ� ���� �ڷ�ƾ�� �����Ѵ�
        StartCoroutine(DieProcess());
    }

    // ��� ���� ó���� �ڷ�ƾ
    IEnumerator DieProcess()
    {
        // ĳ���� ��Ʈ�ѷ��� ��Ȱ��ȭ�Ѵ�
        // cc.enabled = false;

        // 2�� ���� ��ٸ� ���� �ڱ��ڽ��� �����Ѵ�
        yield return new WaitForSeconds(2.0f);
        print("�Ҹ�!");
        Destroy(gameObject);
    }

    // ������ ó�� �Լ�
    public void HitEnemy(int hitPower)
    {
        // �ǰ�, ���, ���� ������ ��쿡�� �Լ� ��� ����
        if (e_State == VagrantState.Hurt || e_State == VagrantState.Death)
        {
            return;
        }

        // �÷��̾��� ���ݷ¸�ŭ �� ü���� ���ҽ����ش�
        HP -= hitPower;

        // ������Ʈ�� �̵��� �����ϰ� ��θ� �ʱ�ȭ

        // �� ü���� 0���� ũ�� �ǰ� ���·� ��ȯ
        if (HP > 0)
        {
            e_State = VagrantState.Hurt;

            // �ǰ� �ִϸ��̼� ���
            anim.SetTrigger("Hurt");
            Hurt();
        }
        // �׷��� �ʴٸ� ��� ���·� ��ȯ
        else
        {
            e_State = VagrantState.Death;

            // ��� �ִϸ��̼� ���
            anim.SetTrigger("Death");
            Death();
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
        e_State = VagrantState.Idle;
    }
}
