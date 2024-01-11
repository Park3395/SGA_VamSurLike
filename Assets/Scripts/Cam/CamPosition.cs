using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamPosition : MonoBehaviour
{
    [SerializeField]
    Transform originPos;

    bool iscollision = false;

    private void OnCollisionEnter(Collision collision)
    {
        iscollision = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("exit");
        iscollision = false;
    }

    private void Update()
    {
        if (!iscollision)
            this.transform.position = originPos.position;
    }
}
