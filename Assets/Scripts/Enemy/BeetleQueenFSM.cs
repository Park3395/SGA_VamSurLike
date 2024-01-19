using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeetleQueenFSM : MonoBehaviour
{
    private enum BQState
    {
        Spawn,
        Idle,
        Walk,
        BeetleSpawn,
        FireSpit,
        Damaged,
        Flinch,
        Death
    }

    BQState e_State;

    public float HP;
    public float MaxHP;
    public float FireSpitPower;
    public float FireSpitDelay;
    public float BeetleSpawnDelay;

    Animator anim;

    NavMeshAgent agent;

    private void Start()
    {
        e_State = BQState.Spawn;

        anim = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        switch (e_State)
        {
            case BQState.Spawn:
                Spawn();
                break;
            case BQState.Idle:
                Idle();
                break;
            case BQState.Walk:
                Walk();
                break;
            case BQState.BeetleSpawn:
                BeetleSpawn();
                break;
            case BQState.FireSpit:
                //Hurt();
                break;
            case BQState.Damaged:
                //Damaged();
                break;
            case BQState.Death:
                break;
        }
    }

    void Spawn()
    {
        StartCoroutine(SpawnToRun());
    }

    IEnumerator SpawnToRun()
    {
        yield return new WaitForSeconds(3.5f);
    }

    void Idle()
    {

    }

    void Walk()
    {

    }

    void BeetleSpawn()
    {

    }
    
    void FireSpit()
    {

    }
}
