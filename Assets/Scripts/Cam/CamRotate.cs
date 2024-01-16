using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    // ȸ�� �ӵ�
    [SerializeField]
    float rotSpeed;

    // ���콺 ���� �̵� ó��
    float mx;
    // ���콺 ���� �̵� ó��
    float my;

    private void Start()
    {
        // ����� ȸ�� �ӵ� ��������
        rotSpeed = GetComponentInParent<PlayerStat>().RotSpeed;
    }

    private void Update()
    {
        // ���콺 ���� �Է�
        float mouseX = Input.GetAxis("Mouse X");
        // ���콺 ���� �Է�
        float mouseY = Input.GetAxis("Mouse Y");

        // ���콺 �Է°� ȸ���ӵ� ����
        mx += mouseX * rotSpeed * Time.deltaTime;
        my += mouseY * rotSpeed * Time.deltaTime;

        // ī�޶� ���� ȸ�� �ּ�,�ִ밪 ����
        my = Mathf.Clamp(my, -30f, 90f);
        
        // ī�޶� ȸ��
        transform.eulerAngles = new Vector3(0, mx, my);
    }
}
