using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGolemSmack : MonoBehaviour
{
    PlayerStat pStat;
    public GameObject golem;
    StoneGolemFSM eFSM;

    private void Start()
    {
        pStat = PlayerStat.instance;
        eFSM = golem.GetComponent<StoneGolemFSM>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            pStat.NowHP -= eFSM.attackPower;
        }
    }
}
