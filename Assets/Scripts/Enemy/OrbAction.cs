using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbAction : MonoBehaviour
{
    GameObject player;
    public GameObject vagrant;
    PlayerStat pStat;
    VagrantFSM eFSM;
    public AudioSource destroySoundEffect;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pStat = PlayerStat.instance;
        eFSM = vagrant.GetComponent<VagrantFSM>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            // ����� �� �÷��̾��� hp ����
            pStat.NowHP -= eFSM.attackPower;
            destroySoundEffect.Play();
            Destroy(gameObject);
        }

        // �浹ü�� ���̾ Ground��� ������Ʈ ����
        if (other.gameObject.layer == 8)
        {
            destroySoundEffect.Play();
            Destroy(gameObject);
        }
    }
}
