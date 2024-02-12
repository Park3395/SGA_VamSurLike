using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    float duration = 0.5f;

    private void Update()
    {
        duration -= Time.deltaTime;

        if(duration <= 0f)
            Destroy(this.gameObject);
    }
}
