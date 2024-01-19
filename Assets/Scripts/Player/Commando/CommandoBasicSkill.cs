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
    [SerializeField]
    Transform aim;

    void ShootBulletL()
    {
        Debug.Log("spawn");
        Instantiate(basicBullet, shootPosL.position, new Quaternion(), aim);
    }

    void ShootBulletR()
    {
        Debug.Log("spawn");
        Instantiate(basicBullet, shootPosR.position, new Quaternion(), aim);
    }
}
