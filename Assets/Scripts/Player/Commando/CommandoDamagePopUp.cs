using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandoDamagePopUp : MonoBehaviour
{
    PlayerStat pStat;
    float dmg;
    GameObject hurtBox;
    Transform popUpPos;

    void Start()
    { 
        pStat = PlayerStat.instance;
        dmg = pStat.Dmg;
        hurtBox = GameObject.FindGameObjectWithTag("HurtBox");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 9)
        // 데미지 팝업 띄울 위치 변경중.
            Damage_PopUp_Generator.current.CreatePopUp(hurtBox.transform.position, dmg.ToString());
    }
}
