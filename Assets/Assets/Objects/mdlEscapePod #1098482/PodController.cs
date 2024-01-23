using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PodController : MonoBehaviour
{
    private Animator animator;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject player;

    void Start()
    {
        animator = GetComponent<Animator>();
        
        // 2���� ���� �ִϸ��̼��� �����ϴ� �Լ� ȣ��
        StartCoroutine(DelayedFunction());
    }

    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.E))
        {
            // �������� �ִϸ��̼ǽ���
            animator.Play("PodOpen");
            // ����ī�޶� ��Ȱ��ȭ
            virtualCamera.enabled = false;
            // �÷��̾� Ȱ��ȭ
            player.SetActive(true);
        }
    }

    IEnumerator DelayedFunction()
    {
        // 2�� ���
        yield return new WaitForSeconds(2.0f);
        // 2�� �Ŀ� ����� �Լ� ȣ��
        animator.Play("PodSpawn");        

    }
}
