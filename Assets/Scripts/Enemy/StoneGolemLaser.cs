using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGolemLaser : MonoBehaviour
{
    PlayerStat pStat;
    StoneGolemFSM efsm;
    GameObject golem;

    private void Start()
    {
        pStat = PlayerStat.instance;
        golem = GameObject.FindGameObjectWithTag("StoneGolem");
        efsm = golem.GetComponent<StoneGolemFSM>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Debug.Log("파이어볼 충돌");
            pStat.NowHP -= efsm.attackPower;
            Destroy(gameObject);
        }

        // 충돌체의 레이어가 Ground라면 오브젝트 삭제
        if (other.gameObject.layer == 8)
            Destroy(gameObject);
    }
}
