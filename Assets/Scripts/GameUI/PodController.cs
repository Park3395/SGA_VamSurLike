using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class PodController : MonoBehaviour
{
    private Animator escapePodAnimator;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject explosionFx;
    public Canvas pressE;
    public Text mapNameText;

    void Start()
    {
        escapePodAnimator = GetComponent<Animator>();
        
        // 3���� ���� �ִϸ��̼��� �����ϴ� �Լ� ȣ��
        StartCoroutine(DelayedFunction());
    }

    void Update()
    {    
        // E������� ������ �������� E������
        if (Input.GetKeyDown(KeyCode.E)&&pressE.gameObject.activeSelf)
        {
            // �������� �ִϸ��̼ǽ���
            escapePodAnimator.Play("PodOpen");
            
        }
    }

    IEnumerator DelayedFunction()
    {
        // 1�� ���
        yield return new WaitForSeconds(1.0f);
        mapNameText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.0f);
        escapePodAnimator.Play("PodSpawn");

        yield return new WaitForSeconds(1.5f);
        StopShake();

        yield return new WaitForSeconds(1.5f);
        mapNameText.gameObject.SetActive(false);
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
