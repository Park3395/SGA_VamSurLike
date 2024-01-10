using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public float findDistance = 5;

    public float attackDistance = 0.01f;

    CharacterController cc;

    Animator anim;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        e_State = BeetleState.Spawn;

        player = GameObject.Find("Player").transform;

        cc = GetComponent<CharacterController>();

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
                Hurt();
                break;
            case BeetleState.Death:
                //Damaged();
                break;
        }
    }

    void Spawn()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Spawn") && Vector3.Distance(transform.position, player.position) < findDistance)
        {
            e_State = BeetleState.Run;

            anim.SetTrigger("IdleToRun");
        }
    }

    void Run()
    {
        if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            ////이동 방향
            //Vector3 dir = (player.position - transform.position).normalized;

            ////캐릭터 컨트롤러를 사용하여 이동
            //cc.Move(dir * Time.deltaTime);

            ////플레이어를 향해 방향 전환
            //transform.forward = dir;
        }
    }
        void Attack()
    {

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
}
