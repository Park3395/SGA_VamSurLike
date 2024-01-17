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
    float dis = 7.0f;

    private void Awake()
    {
    }

    void Update()
    {
        Vector3 dir = Player.position - Target.position;
        dir.Normalize();

        dir = Quaternion.AngleAxis(30f,dir) * dir * dis;
        Debug.Log(dir);

        Vector3 move = Target.position + dir;
        
        this.transform.position = move;
        
        // ī�޶� ������ Target���� �ʱ�ȭ
        this.transform.LookAt(Target);
    }
}
