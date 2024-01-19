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

    // 추적 사거리
    public float findDistance = 40.0f;
    // 기본 공격 범위
    public float attackDistance = 6.0f;
    // 레이저 공격 범위
    public float skillDistance = 20.0f;

    public float HP = 480;
    public float MaxHP = 480;
    public float AttackPower = 20;
    public float AttackDelay = 1.0f;

    // laser 
    public float initialLaserDuration = 3.0f;
    public float fixedLaserDuration = 1.0f;

    // HP 슬라이더
    public Slider hpSlider;

    Animator anim;

    // 플레이어의 위치
    Transform player;

    // 내비게이션 메쉬 컴포넌트
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        // 초기 상태 : 스폰
        e_State = StoneGolemState.Spawn;

        // 플레이어 위치 좌표 가져오기
        player = GameObject.Find("Player").transform;

        // 자식 오브젝트의 애니메이터 컴포넌트 가져오기
        anim = GetComponent<Animator>();

        // 내비게이션 에이전트 컴포넌트 가져오기
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // 현재 상태를 검사하고 상태별로 정해진 기능을 수행한다
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

        // 현재 HP를 슬라이더에 반영
        hpSlider.value = (float)HP / (float)MaxHP;
    }

    // 스폰 상태
    void Spawn()
    {
        // beetle이 플레이어를 바라보도록 설정
        transform.forward = player.position;
        // 스폰 애니메이션이 완전히 끝난 후 플레이어를 추적하도록 4.0초의 대기시간을 가진 코루틴함수 사용.
        StartCoroutine(SpawnToRun());
        // 플레이어를 인식할 수 있는 거리 내에 들어오면
        if (Vector3.Distance(transform.position, player.position) < findDistance)
        {
            // enum변수의 상태를 Run으로 전환
            e_State = StoneGolemState.Skill;
        }
    }

    IEnumerator SpawnToRun()
    {
        yield return new WaitForSeconds(4.0f);
    }

    // 이동 상태
    void Run()
    {
        // 현재 위치가 공격 사거리보다 크다면 플레이어를 향해 이동
        if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            Vector3 dir = (player.position - transform.position).normalized;

            transform.forward = dir;

            // 에이전트의 이동을 정지하고 경로를 초기화
            agent.isStopped = true;
            agent.ResetPath();

            // 내비게이션으로 접근하는 최소 거리를 공격 가능한 거리로 설정
            agent.stoppingDistance = attackDistance;

            // 내비게이션의 목적지를 플레이어의 위치로 설정
            agent.destination = player.position;
        }
        // 플레이어와의 거리가 공격 사거리 이내라면
        else if (Vector3.Distance(transform.position, player.position) <= attackDistance)
        {
            // enum변수 상태를 Attack으로 전환
            Debug.Log("Attack");
            e_State = StoneGolemState.Attack;
        }
    }

    // 공격 상태
    void Attack()
    {
        // 플레이어가 공격 범위 내라면 공격을 시작한다
        if (Vector3.Distance(transform.position, player.position) <= attackDistance)
        {
            anim.Play("Attack");
        }
        // 공격 범위를 벗어났다면 현재 상태를 Run으로 전환한다 (재추격)
        else
        {
            e_State = StoneGolemState.Run;
            anim.SetTrigger("AttackToRun");
        }
    }

    // 플레이어의 데미지 처리 함수
    public void AttackAction()
    {
        //player.GetComponent<PlayerMove>().DamageAction(attackPower);
    }

    // 데미지 처리 함수
    public void HitEnemy(int hitPower)
    {
        // 스폰, 피격, 사망 상태일 경우에는 함수 즉시 종료
        if (e_State == StoneGolemState.Spawn || e_State == StoneGolemState.Hurt || e_State == StoneGolemState.Death)
        {
            return;
        }

        // 플레이어의 공격력만큼 적 체력 감소.
        HP -= hitPower;

        // 에이전트의 이동을 정지하고 경로를 초기화
        agent.isStopped = true;
        agent.ResetPath();

        // 적 체력이 0보다 크면 피격 상태로 전환
        if (HP > 0)
        {
            e_State = StoneGolemState.Hurt;

            // 피격 애니메이션 재생
            anim.SetTrigger("Hurt");
            Hurt();
        }
        // 그렇지 않으면 사망 상태로 전환
        else
        {
            e_State = StoneGolemState.Death;

            // 사망 애니메이션 재생
            anim.SetTrigger("Death");
            Die();
        }
    }

    // 레이저 스킬
    void Skill()
    {
        if (Vector3.Distance(transform.position, player.position) <= skillDistance)
        {
            // Laser animation 재생
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
        // LineRenderer 컴포넌트를 자식객체의 Inspector에서 찾기.
        LineRenderer lR = GetComponentInChildren<LineRenderer>();
        lR.enabled = true;

        // LineRenderer의 위치 갯수
        lR.positionCount = 2;

        // ???? mdlGolem안의 child인 MuzzleLaser의 위치 받아오기.
        lR.SetPosition(0, GameObject.FindGameObjectWithTag("LaserPos").transform.position);
        // 경과 시간
        float elapsedTime = 0f;

        // 경과 시간이 초기 레이저 설정 시간(3초)가 될 때까지 조준
        while (elapsedTime < initialLaserDuration)
        {
            lR.SetPosition(1, player.position);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 플레이어의 마지막 위치를 저장
        Vector3 mPos = player.position;
        elapsedTime = 0f;
        // 1초 동안 레이저가 데미지를 입힐 수 있는 상태
        while (elapsedTime < fixedLaserDuration)
        {
            anim.SetTrigger("LaserAttack");
            // player의 마지막 위치와 연결
            lR.SetPosition(1, mPos);
            elapsedTime += Time.deltaTime;
            // 이 때 플레이어가 레이저에 닿으면 데미지를 입음
            /*
            // 데미지 처리 함수. 


             */
            yield return null;
        }

        // 레이저 비활성화
        lR.enabled = false;

        // 레이저 발사 후 1초 대기
        yield return new WaitForSeconds(1.0f);

        // enum 상태를 Run으로 전환
        e_State = StoneGolemState.Run;
        anim.SetTrigger("SkillToRun");
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
        e_State = StoneGolemState.Run;
    }

    void Die()
    {
        // 진행 중인 피격 코루틴 함수를 중지한다
        StopAllCoroutines();

        // 사망 상태를 처리하기 위한 코루틴을 실행한다
        StartCoroutine(DieProcess());
    }

    // 사망 상태 처리용 코루틴
    IEnumerator DieProcess()
    {
        anim.Play("Death");

        // 2초 동안 기다린 이후 자기자신을 제거한다
        yield return new WaitForSeconds(2.0f);
        print("소멸!");
        Destroy(gameObject);
    }
}