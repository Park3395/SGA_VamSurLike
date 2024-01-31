using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleHeadButt : MonoBehaviour
{
    PlayerStat pStat;
    public GameObject beetle;
    BeetleFSM eFSM;

    private void Start()
    {
        pStat = PlayerStat.instance;
        eFSM = beetle.GetComponent<BeetleFSM>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            pStat.NowHP -= eFSM.AttackPower;
        }
    }
}
