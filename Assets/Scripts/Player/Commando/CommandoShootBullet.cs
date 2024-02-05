using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandoShootBullet : MonoBehaviour
{
    GameObject basicBullet;
    Transform shootPosL;
    Transform shootPosR;

    private void Awake()
    {
        shootPosL = GetComponentInParent<PlayerSkill>().ShootPos;
        shootPosR = GetComponentInParent<PlayerSkill>().ShootPos_Sub;
        basicBullet = GetComponentInParent<PlayerSkill>().basicBullet;
    }

    void ShootBulletL()
    {
        Instantiate(basicBullet, shootPosL.position, new Quaternion());
    }

    void ShootBulletR()
    {
        Instantiate(basicBullet, shootPosR.position, new Quaternion());
    }

}
