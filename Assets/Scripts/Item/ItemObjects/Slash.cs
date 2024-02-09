using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    float duration = 1.0f;

    private void Update()
    {
        duration -= Time.deltaTime;

        if(duration <= 0f)
            Destroy(this.gameObject);
    }
}
