using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleHeadButt : MonoBehaviour
{
    public GameObject player;
    PlayerStat pStat;
    public GameObject beetle;
    BeetleFSM eFSM;

    private void Start()
    {
        pStat = player.GetComponent<PlayerStat>();
        eFSM = beetle.GetComponent<BeetleFSM>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            pStat.NowHP -= eFSM.AttackPower;
        }
    }
}
