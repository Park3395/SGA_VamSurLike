using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // ī�޶� ��ġ ������Ʈ
    [SerializeField]
    Transform Target;

    // �÷��̾� ������Ʈ
    [SerializeField]
    Transform Player;

    // ī�޶� ȸ�� �ӵ�
    [SerializeField]
    public float rotSpeed = 200f;

    // ȸ�� ��
    float mx = 0;
    float my = 0;

    void Update()
    {
        this.transform.LookAt(new Vector3(0,Player.position.y,Player.position.z));
        this.transform.position = Target.position;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        mx += mouseX * rotSpeed * Time.deltaTime;
        my += mouseY * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -90f, 90f);
        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
