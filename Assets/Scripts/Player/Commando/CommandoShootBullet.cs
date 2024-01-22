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

    void ShootBulletL()
    {
        Debug.Log("spawn");
        //shootforce = aim.position - shootPosL.position;
        //shootforce.Normalize();
        ShootSqn();
        Instantiate(basicBullet, shootPosL.position, new Quaternion(), this.transform);
    }

    void ShootBulletR()
    {
        Debug.Log("spawn");
        //shootforce = aim.position - shootPosR.position;
        //shootforce.Normalize();
        ShootSqn();
        Instantiate(basicBullet, shootPosR.position, new Quaternion(), this.transform);
    }

    void ShootSqn()
    {
        RaycastHit hit;
        Physics.Raycast(cam.position, cam.forward, out hit, 30f);
        if (hit.point != Vector3.zero)
            shootforce = hit.point - focus.position;
        else
        {
            shootforce = aim.position - cam.position;
            Vector3 temp = aim.position - focus.position;
            shootforce += temp;
        }
        shootforce.Normalize();
    }
}
