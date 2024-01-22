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
    [SerializeField]
    Transform aim;
    [SerializeField]
    Transform cam;
    [SerializeField]
    Transform focus;

    public Vector3 shootforce;

    private void Update()
    {
        //Vector3 temp1 = aim.position - focus.position;
        //temp1.Normalize();
        //Vector3 temp2 = aim.position - cam.position;
        //temp2.Normalize();
        //shootforce = temp1 + temp2;

        shootforce = aim.position - cam.position;
        shootforce.Normalize();
    }

    void ShootBulletL()
    {
        Debug.Log("spawn");
        //shootforce = aim.position - shootPosL.position;
        //shootforce.Normalize();
        Instantiate(basicBullet, shootPosL.position, new Quaternion(), this.transform);
    }

    void ShootBulletR()
    {
        Debug.Log("spawn");
        //shootforce = aim.position - shootPosR.position;
        //shootforce.Normalize();
        Instantiate(basicBullet, shootPosR.position, new Quaternion(), this.transform);
    }
}
