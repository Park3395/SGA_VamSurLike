using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    [SerializeField]
    float rotSpeed;

    float mx = 0f;
    float my;

    private void Start()
    {
        rotSpeed = GetComponentInParent<PlayerStat>().RotSpeed;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        mx += mouseX * rotSpeed * Time.deltaTime;
        my += mouseY * rotSpeed * Time.deltaTime;

        // mx = GetComponentInParent<Transform>().rotation.y;
        my = Mathf.Clamp(my, -30f, 90f);

        //this.transform.forward = this.transform.parent.forward;

        transform.eulerAngles = new Vector3(0, mx, my);
    }
}
