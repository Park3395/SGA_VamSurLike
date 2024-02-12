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
            Debug.Log("���̾ �浹");
            pStat.NowHP -= efsm.attackPower;
            Destroy(gameObject);
        }

        // �浹ü�� ���̾ Ground��� ������Ʈ ����
        if (other.gameObject.layer == 8)
            Destroy(gameObject);
    }
}
