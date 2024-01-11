using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // ī�޶� ��ġ ������Ʈ
    [SerializeField]
    Transform Pos;

    // �÷��̾� ������Ʈ
    [SerializeField]
    Transform Target;

    void Update()
    {
        this.transform.LookAt(Target);
        this.transform.position = Pos.position;
    }
}
