using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeetleFSM : MonoBehaviour
{
    private enum BeetleState
    {
        Spawn,
        Run,
        Attack,
        Hurt,
        Death
    }

    BeetleState e_State;

    // Beetle 정보
    public int hp = 80;
    public int maxhp = 80;
    public int attackPower = 12;
    // HP 슬라이더
    public Slider hpSlider;

    // 플레이어 인식 범위
    public float findDistance = 10.0f;

    // 플레이어 공격 범위
    public float attackDistance = 2.0f;

    Animator anim;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        e_State = BeetleState.Spawn;

        player = GameObject.Find("Player").transform;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 현재 상태를 검사하고 상태별로 정해진 기능을 수행한다
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
                // Hurt();
                break;
            case BeetleState.Death:
                // Death();
                break;
        }

        // HP슬라이더에 현재 체력 반영
        hpSlider.value = (float)hp / (float)maxhp;
    }

    void Spawn()
    {
        transform.forward = player.position;
        StartCoroutine(SpawnToRun());
        if (Vector3.Distance(transform.position, player.position) < findDistance)
        {
            e_State = BeetleState.Run;
            anim.SetTrigger("IdleToRun");
        }
    }

    IEnumerator SpawnToRun()
    {
        yield return new WaitForSeconds(4.0f);
    }

    void Run()
    {
        // 플레이어와의 거리가 공격 범위 밖이면 플레이어를 향해 이동
        if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            Debug.Log("Run");

            //이동 방향
            Vector3 dir = (player.position - transform.position).normalized;

            //플레이어를 향해 방향 전환
            transform.forward = dir;
        }
        // 플레이어와의 거리가 공격 범위 내라면 공격 상태로 전환
        else if (Vector3.Distance(transform.position, player.position) <= attackDistance)
        {
            Debug.Log("Attack");
            e_State = BeetleState.Attack;
        }
    }

    void Attack()
    {
        // 플레이어가 공격 범위 내라면 공격을 시작한다
        if (Vector3.Distance(transform.position, player.position) <= attackDistance)
        {
            anim.SetTrigger("RunToAttack");
        }
        // 공격 범위를 벗어났다면 현재 상태를 Move로 전환한다 (재추격)
        else
        {
            e_State = BeetleState.Run;
            anim.SetTrigger("AttackToRun");
        }
    }

    public void AttackAction()
    {
        // 플레이어가 완성 된 후 수정사항. 데미지 처리 함수
        // player.GetComponent<PlayerMove>().DamageAction(attackPower);
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
        e_State = BeetleState.Run;
    }

    public void HitEnemy(int hitPower)
    {
        if (e_State == BeetleState.Hurt || e_State == BeetleState.Death)
        {
            return;
        }

        // 플레이어의 공격력만큼 적 체력 감소
        hp -= hitPower;
        
        if (hp > 0)
        {
            e_State = BeetleState.Hurt;

            // 피격 애니메이션
            anim.SetTrigger("Hurt");
            Hurt();
        }
        else
        {
            e_State = BeetleState.Death;

            // 사망 애니메이션
            anim.SetTrigger("Death");
            Death();
        }

    }

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
        Destroy(gameObject);
    }
}
