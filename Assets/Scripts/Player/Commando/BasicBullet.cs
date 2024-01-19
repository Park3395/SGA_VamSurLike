using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    Vector3 force;
    float speed = 100f;
    float nowt = 0f;
    float maxt = 3f;

    private void Awake()
    {
        force = transform.position - GetComponentInParent<Transform>().position;
        force.Normalize();
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
