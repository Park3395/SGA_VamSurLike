using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public float nowHP; //���� ü��
    public float maxHP;    //�ִ� ü��
    public Slider HPBarslider;

    void Update()
    {   
        maxHP = PlayerStat.instance.MaxHP;
        nowHP = PlayerStat.instance.NowHP;
        HPBarslider.value = nowHP / maxHP;
    }
}
