using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_PopUp : MonoBehaviour
{
    // 카메라
    public Transform target;

    PlayerStat pStat;
    float dmg;

    private void Awake()
    {
        dmg = pStat.Dmg;
    }

    private void Update()
    {
        // 항상 카메라의 방향과 일치시킨다
        transform.forward = target.forward;
    }
}
