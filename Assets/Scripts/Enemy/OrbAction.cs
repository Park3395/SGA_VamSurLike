using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbAction : MonoBehaviour
{
    GameObject player;
    public GameObject enemy;
    VagrantFSM eFSM;
    PlayerStat pStat;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pStat = player.GetComponent<PlayerStat>();
        eFSM = enemy.GetComponent<VagrantFSM>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Collision with Player");
            // ����� �� �÷��̾��� hp ����
            pStat.NowHP -= eFSM.attackPower;
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
