using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandoBasicBullet : MonoBehaviour
{
    Vector3 force;
    float speed = 10f;
    float nowt = 0f;
    float maxt = 3f;

    PlayerStat stat;
    float dmg;

    private void Awake()
    {
        force = GetComponentInParent<CommandoShootBullet>().shootforce;

        stat = PlayerStat.instance;
        dmg = stat.Dmg;
    }

    private void Update()
    {
        if (nowt < maxt)
            nowt += Time.deltaTime;
        else
            Destroy(this.gameObject);
        Debug.Log(force);
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
    }
}
