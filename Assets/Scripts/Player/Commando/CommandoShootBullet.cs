using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandoShootBullet : MonoBehaviour
{
    [SerializeField]
    GameObject basicBullet;

    [SerializeField]
    Transform shootPosL;
    [SerializeField]
    Transform shootPosR;

    public Vector3 shootforce;

    void ShootBulletL()
    {
        Instantiate(basicBullet, shootPosL.position, new Quaternion());
    }

    void ShootBulletR()
    {
        Instantiate(basicBullet, shootPosR.position, new Quaternion());
    }

}
