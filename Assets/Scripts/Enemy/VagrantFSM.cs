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

    // Vagrant 정보
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

    // player위치를 받아올 Transform
    private GameObject player;

    // 공격 투사체
    [SerializeField] private GameObject OrbFactory;

    // 투사체가 발사될 위치
    [SerializeField] private Transform missileLaunch;

    // 유도탄 스킬
    // 유도탄이 발사될 위치
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
        // 스킬 쿨타임
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

        // 플레이어의 위치가 공격 범위 밖이라면 플레이어를 향해 이동
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
        // Tracking Bomb 인스턴스화
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

        // 유도탄
        //var leadTimePercentage = Mathf.InverseLerp(minDistancePredict, maxDistancePredict, Vector3.Distance(Orb.transform.position, player.transform.position));

        //var predictionTime = Mathf.Lerp(0, maxTimePrediction, leadTimePercentage);

        //// 수정
        //var standardPrediction = player.transform.position + player.GetComponent<CharacterController>().velocity * predictionTime;

        //var deviation = new Vector3(Mathf.Cos(Time.time * deviationSpeed), 0, 0);

        //var predictionOffset = Orb.transform.TransformDirection(deviation) * deviationAmount * leadTimePercentage;

        //deviatedPrediction = standardPrediction + predictionOffset;

        //var heading = deviatedPrediction - Orb.transform.position;

        //var rotation = Quaternion.LookRotation(heading);

        //rb.MoveRotation(Quaternion.RotateTowards(Orb.transform.rotation, rotation, trackingRotSpeed * Time.deltaTime));
    }

    // 사망 상태
    void Death()
    {
        // 진행 중인 피격 코루틴 함수를 중지한다
        StopAllCoroutines();

        // 사망 상태를 처리하기 위한 코루틴을 실행한다
        StartCoroutine(DieProcess());
    }

    // 사망 상태 처리용 코루틴
    IEnumerator DieProcess()
    {
        // 캐릭터 컨트롤러를 비활성화한다
        // cc.enabled = false;

        // 2초 동안 기다린 이후 자기자신을 제거한다
        yield return new WaitForSeconds(2.0f);
        print("소멸!");
        Destroy(gameObject);
    }

    // 데미지 처리 함수
    public void HitEnemy(int hitPower)
    {
        // 피격, 사망, 복귀 상태일 경우에는 함수 즉시 종료
        if (e_State == VagrantState.Hurt || e_State == VagrantState.Death)
        {
            return;
        }

        // 플레이어의 공격력만큼 적 체력을 감소시켜준다
        HP -= hitPower;

        // 에이전트의 이동을 정지하고 경로를 초기화

        // 적 체력이 0보다 크면 피격 상태로 전환
        if (HP > 0)
        {
            e_State = VagrantState.Hurt;

            // 피격 애니메이션 재생
            anim.SetTrigger("Hurt");
            Hurt();
        }
        // 그렇지 않다면 사망 상태로 전환
        else
        {
            e_State = VagrantState.Death;

            // 사망 애니메이션 재생
            anim.SetTrigger("Death");
            Death();
        }
    }

    // 피격 상태
    void Hurt()
    {
        // 피격 상태를 처리하는 코루틴 함수를 호출한다
        StartCoroutine(DamageProcess());
    }

    // 피격 상태 처리용 코루틴
    IEnumerator DamageProcess()
    {
        // 피격 애니메이션 재생 시간만큼 기다린다
        yield return new WaitForSeconds(1.0f);

        // 현재 상태를 이동으로 전환한다
        e_State = VagrantState.Idle;
    }
}
