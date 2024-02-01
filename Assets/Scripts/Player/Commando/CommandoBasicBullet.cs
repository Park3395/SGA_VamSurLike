using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    Vector3 force;
    float speed = 30f;
    float nowt = 0f;
    float maxt = 2f;
    PlayerStat stat;
    float dmg;

    private void Awake()
    {
        stat = PlayerStat.instance;
        dmg = stat.Dmg;

        #region shootforce

        RaycastHit hit;
        Transform cam = Camera.main.transform;

        Ray ray = new Ray(cam.position, cam.forward);
        Vector3 endpoint = ray.origin + (ray.direction * 50f);

        Physics.Raycast(ray, out hit, 50f);

        if (hit.point != Vector3.zero)
        {
            force = hit.point - this.transform.position;
        }
        else
        {
            force = endpoint - this.transform.position;
        }
        force.Normalize();

        #endregion
    }

    private void FixedUpdate()
    {
        if (nowt < maxt)
            nowt += Time.deltaTime;
        else
            Destroy(this.gameObject);
        //Debug.Log(force);
        this.transform.Translate(force*speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Debug.Log("HitEnemy");
            other.gameObject.GetComponent<IHitEnemy>().HitEnemy(dmg);
            Destroy(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
}
