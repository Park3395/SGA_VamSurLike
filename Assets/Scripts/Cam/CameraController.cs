using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // ī�޶� ���� ������Ʈ
    [SerializeField]
    Transform Target;

    void Update()
    {
        // ī�޶� ������ Target���� �ʱ�ȭ
        this.transform.LookAt(Target);
    }
}
