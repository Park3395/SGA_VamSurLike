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
            // 닿았을 때 플레이어의 hp 감소
            pStat.NowHP -= eFSM.attackPower;
            destroySoundEffect.Play();
            Destroy(gameObject);
        }

        // 충돌체의 레이어가 Ground라면 오브젝트 삭제
        if (other.gameObject.layer == 8)
        {
            destroySoundEffect.Play();
            Destroy(gameObject);
        }
    }
}
