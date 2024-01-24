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
    Transform cam;

    public Vector3 shootforce;

    void ShootBulletL()
    {
        Debug.Log("spawn");
        ShootSqn(false);
        Instantiate(basicBullet, shootPosL.position, new Quaternion(), this.transform);
    }

    void ShootBulletR()
    {
        Debug.Log("spawn");
        ShootSqn(true);
        Instantiate(basicBullet, shootPosR.position, new Quaternion(), this.transform);
    }

    void ShootSqn(bool isRight)
    {
        RaycastHit hit;
        Ray ray = new Ray(cam.position, cam.forward);
        Vector3 endpoint = ray.origin + (ray.direction * 30f);
        
        Physics.Raycast(ray, out hit, 30f);
        
        if (hit.point != Vector3.zero)
        {
            if (isRight)
                shootforce = hit.point - shootPosR.position;
            else
                shootforce = hit.point - shootPosL.position;
        }
        else
        {
            if (isRight)
                shootforce = endpoint - shootPosR.position;
            else
                shootforce = endpoint - shootPosL.position;

        }

        shootforce.Normalize();
    }
}
