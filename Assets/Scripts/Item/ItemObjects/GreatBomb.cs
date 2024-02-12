using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatBomb : MonoBehaviour
{
    float t = 4f;

    private void Update()
    {
        t -= Time.deltaTime;

        if (t < 0)
        {
            this.transform.GetChild(0).GetComponent<SphereCollider>().enabled = true;

            StartCoroutine(WaitChild());

            Destroy(this.gameObject);
        }
    }
    IEnumerator WaitChild()
    {
        yield return new WaitUntil(() => this.transform.GetChild(0) == null);
    }
}
