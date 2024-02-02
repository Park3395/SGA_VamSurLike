using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PodController : MonoBehaviour
{
    private Animator escapePodAnimator;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject player;
    public GameObject explosionFx;
    public Canvas pressE;

    void Start()
    {
        escapePodAnimator = GetComponent<Animator>();
        
        // 2���� ���� �ִϸ��̼��� �����ϴ� �Լ� ȣ��
        StartCoroutine(DelayedFunction());
    }

    void Update()
    {    
        // E������� ������ �������� E������
        if (Input.GetKeyDown(KeyCode.E)&&pressE.gameObject.activeSelf)
        {
            // �������� �ִϸ��̼ǽ���
            escapePodAnimator.Play("PodOpen");
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
        escapePodAnimator.Play("PodSpawn");

        yield return new WaitForSeconds(1.5f);
        StopShake();
        pressE.gameObject.SetActive(true);

    }

    void StopShake()
    {        
        if (virtualCamera != null)
        {
            CinemachineBasicMultiChannelPerlin noise = 
                virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

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
        explosionFx.SetActive(true);

    }
}
