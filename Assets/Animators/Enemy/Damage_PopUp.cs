using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_PopUp : MonoBehaviour
{
    // ī�޶�
    public Transform target;

    PlayerStat pStat;
    float dmg;

    private void Awake()
    {
        dmg = pStat.Dmg;
    }

    private void Update()
    {
        // �׻� ī�޶��� ����� ��ġ��Ų��
        transform.forward = target.forward;
    }
}
