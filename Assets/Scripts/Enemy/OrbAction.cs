using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbAction : MonoBehaviour
{
    VagrantFSM fsm;
    PlayerStat p_Stat;

    // �ƹ��͵� �浹�� ���� �ʴ� ���¶� ������ 1/24
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Collision with Player");
            // ����� �� �÷��̾��� hp ����
            //p_Stat.NowHP -= fsm.attackPower;
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
