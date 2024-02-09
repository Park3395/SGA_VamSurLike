using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    PlayerStat playerStat;
    int recoverAmount;

    void Start()
    {
        playerStat = PlayerStat.instance;
        recoverAmount = 30;
    }

    void Update()
    {        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.name == "Player")
        if (other.gameObject.layer == 6)
        {
            gameObject.SetActive(false);
            
            playerStat.NowHP += recoverAmount;
            if(playerStat.NowHP > playerStat.MaxHP)
                playerStat.NowHP = playerStat.MaxHP;
        }
    }

}
