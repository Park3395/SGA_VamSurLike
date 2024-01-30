using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
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

        stat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStat>();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Debug.Log("HitEnemy");
            collision.gameObject.GetComponent<IHitEnemy>().HitEnemy(dmg);
            Destroy(this.gameObject);
        }
    }
}
