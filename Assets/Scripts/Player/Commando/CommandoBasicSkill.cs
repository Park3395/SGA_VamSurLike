using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandoBasicSkill : MonoBehaviour
{
    [SerializeField]
    GameObject basicBullet;
    [SerializeField]
    Transform shootPosL;
    [SerializeField]
    Transform shootPosR;

    void ShootBulletL()
    {
        Debug.Log("spawn");
        Instantiate(basicBullet,shootPosL.position,new Quaternion());
    }

    void ShootBulletR()
    {
        Debug.Log("spawn");
        Instantiate (basicBullet, shootPosR.position,new Quaternion());
    }
}
