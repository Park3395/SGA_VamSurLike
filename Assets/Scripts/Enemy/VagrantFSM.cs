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
        Skill1,
        Skill2,
        Hurt,
        Death
    }

    VagrantState e_State;

    // Vagrant 정보
    public float attackDistance = 60.0f;
    public int HP = 2100;
    public int MaxHP = 2100;
    public int attackPower = 10;
    public float speed = 1.0f;
    public float orbSpeed = 10.0f;

    // animator
    Animator anim;

    // player위치를 받아올 Transform
    Transform player;

    // 공격 투사체
    public GameObject OrbFactory;

    // 투사체가 발사될 위치
    [SerializeField]
    Transform missileLaunch;

    // 유도탄이 발사될 위치
    [SerializeField]
    Transform trackingBomb;

    private void Start()
    {
        e_State = VagrantState.Spawn;

        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
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
            case VagrantState.Skill1:
                Skill1();
                break;
            case VagrantState.Skill2:
                Skill2();
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
        Vector3 p_Pos = new Vector3(player.position.x, 0, player.position.z);

        // 플레이어의 위치가 공격 범위 밖이라면 플레이어를 향해 이동
        if (Vector3.Distance(e_Pos, p_Pos) > attackDistance)
        {
            Vector3 dir = (p_Pos - e_Pos).normalized;
        }
        // 그렇지 않으면 공격
        else if (Vector3.Distance(e_Pos, p_Pos) <= attackDistance)
        {
            // 10초마다 한 번 공격
            e_State = VagrantState.Attack;
            // 12초마다 한 번 공격
            //e_State = VagrantState.Skill1;
        }
    }

    void Attack()
    {
        StartCoroutine(ShootOrbs(1.0f));
        e_State = VagrantState.Skill1;
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

    void Skill1()
    {
        // 조건식
        // Instantiate(Orb, trackingBomb.position, Quaternion.identity, transform);
    }

    void Skill2()
    {

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
