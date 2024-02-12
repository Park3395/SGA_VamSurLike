using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandoDamagePopUp : MonoBehaviour
{
    PlayerStat pStat;
    float dmg;
    GameObject hurtBox;
    Transform popUpPos;

    // Start is called before the first frame update
    void Start()
    { 
        pStat = PlayerStat.instance;
        dmg = pStat.Dmg;
        hurtBox = GameObject.FindGameObjectWithTag("HurtBox");
    }

    // Update is called once per frame
    void Update()
    {
        popUpPos = hurtBox.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        // 데미지 팝업 띄울 위치 변경중.
        Damage_PopUp_Generator.current.CreatePopUp(popUpPos.position, dmg.ToString());
    }
}
