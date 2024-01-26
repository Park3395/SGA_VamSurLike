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
    [SerializeField] private float attackDistance = 60.0f;
    [SerializeField] private int HP = 2100;
    [SerializeField] private int MaxHP = 2100;
    public int attackPower = 10;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float orbSpeed = 10.0f;
    [SerializeField] private float attackDelay = 3;
    [SerializeField] private float skillDelay = 10;
    [SerializeField] private float attackTimer;
    [SerializeField] private float skillTimer;

    // animator
    Animator anim;

    // player��ġ�� �޾ƿ� Transform
    private GameObject player;

    // ���� ����ü
    [SerializeField] private GameObject OrbFactory;

    // ����ü�� �߻�� ��ġ
    [SerializeField] private Transform missileLaunch;

    // ����ź ��ų
    // ����ź�� �߻�� ��ġ
    [SerializeField] private Transform trackingBomb;
    [SerializeField] private float trackingSpeed = 10.0f;
    [SerializeField] private float trackingRotSpeed = 95;
    [SerializeField] private float minDistancePredict = 30;
    [SerializeField] private float maxDistancePredict = 100;
    [SerializeField] private float maxTimePrediction = 5;
    Vector3 standardPrediction, deviatedPrediction;
    [SerializeField] private float deviationAmount = 50;
    [SerializeField] private float deviationSpeed = 2;


    private void Start()
    {
        e_State = VagrantState.Spawn;

        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");

        attackTimer = attackDelay;
        skillTimer = skillDelay;
    }

    private void Update()
    {
        // ��ų ��Ÿ��
        if (e_State != VagrantState.Spawn)
        {
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
        Debug.Log("Idle");
        Vector3 e_Pos = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 p_Pos = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        //transform.forward = p_Pos;

        // �÷��̾��� ��ġ�� ���� ���� ���̶�� �÷��̾ ���� �̵�
        if (Vector3.Distance(e_Pos, p_Pos) > attackDistance)
        {
            Vector3 dir = (p_Pos - e_Pos).normalized;
        }
        if (Vector3.Distance(e_Pos, p_Pos) <= attackDistance && attackTimer <0.0f)
        {
            e_State = VagrantState.Attack;
            attackTimer = attackDelay;
        }
        else if (Vector3.Distance(e_Pos, p_Pos) <= attackDistance && skillTimer < 0.0f)
        {
            anim.SetTrigger("TrackingBomb");
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
            missileLaunch.transform.forward = player.transform.position;
            Debug.Log("ShootOrbs");
            GameObject Orb = Instantiate(OrbFactory);
            Orb.transform.position = missileLaunch.position;
            yield return new WaitForSeconds(duration);
            Rigidbody rb = Orb.GetComponent<Rigidbody>();
            Vector3 playerPos = player.transform.position;
            Vector3 OrbPos = Orb.transform.position;
            rb.AddForce((playerPos - OrbPos).normalized * orbSpeed, ForceMode.Impulse);
        }
    }

    void Skill()
    {
        // Tracking Bomb �ν��Ͻ�ȭ
        // Instantiate(Orb, trackingBomb.position, Quaternion.identity, transform);
        
        StartCoroutine(ShootDelay());
        

        e_State = VagrantState.Idle;
        anim.SetTrigger("TrackingBombToIdle");
    }

    IEnumerator ShootDelay()
    {
        GameObject Orb = Instantiate(OrbFactory);
        Orb.transform.position = trackingBomb.position;
        yield return new WaitForSeconds(2.0f);
        Rigidbody rb = Orb.GetComponent<Rigidbody>();
        rb.velocity = Orb.transform.forward * trackingSpeed;

        // ����ź
        //var leadTimePercentage = Mathf.InverseLerp(minDistancePredict, maxDistancePredict, Vector3.Distance(Orb.transform.position, player.transform.position));

        //var predictionTime = Mathf.Lerp(0, maxTimePrediction, leadTimePercentage);

        //// ����
        //var standardPrediction = player.transform.position + player.GetComponent<CharacterController>().velocity * predictionTime;

        //var deviation = new Vector3(Mathf.Cos(Time.time * deviationSpeed), 0, 0);

        //var predictionOffset = Orb.transform.TransformDirection(deviation) * deviationAmount * leadTimePercentage;

        //deviatedPrediction = standardPrediction + predictionOffset;

        //var heading = deviatedPrediction - Orb.transform.position;

        //var rotation = Quaternion.LookRotation(heading);

        //rb.MoveRotation(Quaternion.RotateTowards(Orb.transform.rotation, rotation, trackingRotSpeed * Time.deltaTime));
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
