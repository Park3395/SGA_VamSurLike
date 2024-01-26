using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbAction : MonoBehaviour
{
    GameObject player;
    public GameObject vagrant;
    PlayerStat pStat;
    VagrantFSM eFSM;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pStat = player.GetComponent<PlayerStat>();
        eFSM = vagrant.GetComponent<VagrantFSM>();
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Collision with Player");
            // 닿았을 때 플레이어의 hp 감소
            pStat.NowHP -= eFSM.attackPower;
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
