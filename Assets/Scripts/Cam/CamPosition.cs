using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamPosition : MonoBehaviour
{
    // ī�޶� Ÿ�� ������Ʈ
    [SerializeField]
    Transform Target;

    // Ÿ�ٰ� ī�޶� �⺻ ��ġ ������ �Ÿ�
    float dis;

    private void Start()
    {
        // �Ÿ� �ʱ�ȭ
        dis = Vector3.Distance(this.transform.position, Target.position);
    }

    private void Update()
    {
        // ����ĳ��Ʈ ���� ������ ���� forward ���� �ʱ�ȭ
        this.transform.LookAt(Target);

        // ����ĳ��Ʈ ���� (ī�޶� Ÿ�ٿ��� ī�޶� ��ġ �������� ����)
        RaycastHit hit;
        Physics.Raycast(Target.transform.position, -this.transform.forward, out hit, dis);

        // ����ĳ��Ʈ�� �浹 ��ü�� �ִ� ��� �浹 ��ġ�� ī�޶� �̵�
        if(hit.point != Vector3.zero)
        {
            Camera.main.transform.position = hit.point;
        }
        // ���� ��� ī�޶� �⺻ ��ġ�� ī�޶� �̵�
        else
        {
            Camera.main.transform.position = this.transform.position;
        }

        /// add) ī�޶��� �̼��� ���ո� ����
    }
}
