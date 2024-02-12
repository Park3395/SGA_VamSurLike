using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Vector3 force;
    float speed = 10f;
    float nowt = 0f;
    float maxt = 2f;

    private void Awake()
    {
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

    private void Update()
    {
        if (nowt < maxt)
            nowt += Time.deltaTime;
        else
            Destroy(this.gameObject);

        this.transform.Translate(force * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        this.transform.GetChild(0).GetComponent<SphereCollider>().enabled = true;

        StartCoroutine(WaitChild());

        Destroy(this.gameObject);
    }

    IEnumerator WaitChild()
    {
        yield return new WaitUntil(() => this.transform.GetChild(0) == null);
    }
}
