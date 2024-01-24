using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PodController : MonoBehaviour
{
    private Animator animator;
    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin noise;
    public GameObject Player;
    public GameObject ExplosionFx;

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
            VirtualCamera.enabled = false;
            // �÷��̾� Ȱ��ȭ
            Player.SetActive(true);
        }
    }

    IEnumerator DelayedFunction()
    {
        // 2�� ���
        yield return new WaitForSeconds(2.0f);
        // 2�� �Ŀ� ����� �Լ� ȣ��
        animator.Play("PodSpawn");

        yield return new WaitForSeconds(1.5f);
        StopShake();

    }

    void StopShake()
    {        
        if (VirtualCamera != null)
        {
            CinemachineBasicMultiChannelPerlin noise = VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            if (noise != null)
            {
                // ȭ�� ���� ����
                noise.m_AmplitudeGain = 0f;
                noise.m_FrequencyGain = 0f;
            }
        }

        Transform fx1Transfrom = transform.Find("FX_FlameThrower");
        // ���ּ��ڿ� �� ȿ�� �Ⱥ��̰�
        fx1Transfrom.gameObject.SetActive(false);

        // ����ȿ�� ����
        ExplosionFx.SetActive(true);

    }
}
