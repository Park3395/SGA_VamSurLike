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
        // ������ �˾� ��� ��ġ ������.
        Damage_PopUp_Generator.current.CreatePopUp(popUpPos.position, dmg.ToString());
    }
}
