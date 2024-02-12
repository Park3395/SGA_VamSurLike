using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttatchBomb : MonoBehaviour
{
    Vector3 force;
    float speed = 50f;

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
        force.y += PlayerStat.instance.Gravity * Time.deltaTime;
        this.transform.Translate(force * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(WaitChild());
    }

    IEnumerator WaitChild()
    {
        yield return new WaitForSeconds(2.0f);

        this.transform.GetChild(0).GetComponent<SphereCollider>().enabled = true;

        yield return new WaitUntil(() => this.transform.GetChild(0) == null);

        Destroy(this.gameObject);
    }
}
