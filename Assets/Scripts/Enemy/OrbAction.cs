using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbAction : MonoBehaviour
{
    VagrantFSM fsm;
    PlayerStat p_Stat;

    // 아무것도 충돌이 되지 않는 상태라 수정중 1/24
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Collision with Player");
            // 닿았을 때 플레이어의 hp 감소
            //p_Stat.NowHP -= fsm.attackPower;
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
