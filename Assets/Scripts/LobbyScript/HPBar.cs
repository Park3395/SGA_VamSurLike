using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public float nowHP; //현재 체력
    public float maxHP;    //최대 체력
    public Slider HPBarslider;

    void Update()
    {   
        maxHP = PlayerStat.instance.MaxHP;
        nowHP = PlayerStat.instance.NowHP;
        HPBarslider.value = nowHP / maxHP;
    }
}
