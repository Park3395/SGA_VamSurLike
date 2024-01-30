using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    Vector3 force;
    float speed = 10f;
    float nowt = 0f;
    float maxt = 3f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Emeny"))
        {
            // 피격함수 호출
        }
    }
    private void Awake()
    {
        force = GetComponentInParent<CommandoShootBullet>().shootforce;
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
}
