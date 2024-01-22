using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // ī�޶� ���� ������Ʈ
    [SerializeField]
    Transform Target;
    [SerializeField]
    Transform Player;

    [SerializeField]
    float dis = 6.0f;

    Transform localtran;

    private void Awake()
    {
        localtran = Instantiate(Target,Target);
    }

    void Update()
    {
        localtran.SetLocalPositionAndRotation(new Vector3(0, -1, 0), Target.localRotation);

        Vector3 dir = Player.position - localtran.position;
        dir.Normalize();

        dir *= dis;

        Vector3 move = Target.position + dir;

        this.transform.position = move;
        
        // ī�޶� ������ Target���� �ʱ�ȭ
        this.transform.LookAt(Target);
        // ����ĳ��Ʈ ���� (ī�޶� Ÿ�ٿ��� ī�޶� ��ġ �������� ����)
        RaycastHit hit;
        Physics.Raycast(Target.transform.position, -this.transform.forward, out hit, dis);

        // ����ĳ��Ʈ�� �浹 ��ü�� �ִ� ��� �浹 ��ġ�� ī�޶� �̵�
        if (hit.point != Vector3.zero)
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
