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

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Collision with Player");
            // ����� �� �÷��̾��� hp ����
            pStat.NowHP -= eFSM.attackPower;
            Destroy(gameObject);
        }

        // �浹ü�� ���̾ Ground��� ������Ʈ ����
        if (other.gameObject.layer == 8)
            Destroy(gameObject);
    }
}
