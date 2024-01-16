using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    [SerializeField]
    Transform togo;

    Vector3 force;
    float speed = 1f;

    private void Awake()
    {
        force = transform.position - togo.position;
        force.Normalize();
    }

    private void Update()
    {
        this.transform.Translate(force*speed*Time.deltaTime);
    }
}
