using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundImpact : MonoBehaviour
{
    float duration = 1.0f;

    private void Update()
    {
        duration -= Time.deltaTime;
        this.transform.localScale = Vector3.one * 0.2f;

        if (duration <= 0f)
            Destroy(this.gameObject);
    }
}
