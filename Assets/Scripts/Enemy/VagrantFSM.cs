using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VagrantFSM : MonoBehaviour, IHitEnemy
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
    public float HP = 2100;
    public float MaxHP = 2100;
    // HP 슬라이더
    [SerializeField] private Slider hpSlider;
    [SerializeField] private Slider UISlider;
    [SerializeField] private GameObject BossUI;
    public int attackPower = 10;
    [SerializeField] private float orbSpeed = 10.0f;
    [SerializeField] private float attackDistance = 60.0f;
    [SerializeField] private float attackDelay = 3;
    [SerializeField] private float skillDelay = 10;
    [SerializeField] private float attackTimer;
    [SerializeField] private float skillTimer;

    // animator
    private Animator anim;

    // player 게임오브젝트
    private GameObject player;

    // 공격 투사체
    [SerializeField] private GameObject OrbFactory;
    // 투사체가 발사될 위치
    [SerializeField] private Transform missileLaunch;

    // 유도탄 스킬
    [SerializeField] private GameObject trackingBomb;
    // 유도탄이 발사될 위치
    [SerializeField] private Transform trackingBombPos;

    private void Start()
    {
        e_State = VagrantState.Spawn;

        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");

        attackTimer = attackDelay;
        skillTimer = skillDelay;
        BossUI.SetActive(false);
    }

    private void Update()
    {
        // 스킬 쿨타임 (스폰중이 아닐 때)
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

        // 현재 HP를 슬라이더에 반영
        hpSlider.value = (float)HP / (float)MaxHP;
        UISlider.value = (float)HP / (float)MaxHP;
    }

    void Spawn()
    {
        StartCoroutine(SpawnAnimation());
        e_State = VagrantState.Idle;
    }

    // 애니메이션 스폰동안 대기
    IEnumerator SpawnAnimation()
    {
        yield return new WaitForSeconds(1.5f);
        BossUI.SetActive(true);
    }

    // 소환후 상태
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

    // 공격
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
        StartCoroutine(ShootDelay());
        
        e_State = VagrantState.Idle;
        anim.SetTrigger("TrackingBombToIdle");
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject trackingOrb = Instantiate(trackingBomb);
        trackingOrb.transform.position = trackingBombPos.position;
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
        // 2초 동안 기다린 이후 자기자신을 제거한다
        yield return new WaitForSeconds(2.0f);
        print("소멸!");
        BossUI.SetActive(false);
        Destroy(gameObject);
    }

    // 데미지 처리 함수
    public void HitEnemy(float hitPower)
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
