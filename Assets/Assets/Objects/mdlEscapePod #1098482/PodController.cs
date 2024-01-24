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
        
        // 2초후 스폰 애니메이션을 실행하는 함수 호출
        StartCoroutine(DelayedFunction());
    }

    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 문열리는 애니메이션실행
            animator.Play("PodOpen");
            // 가상카메라 비활성화
            VirtualCamera.enabled = false;
            // 플레이어 활성화
            Player.SetActive(true);
        }
    }

    IEnumerator DelayedFunction()
    {
        // 2초 대기
        yield return new WaitForSeconds(2.0f);
        // 2초 후에 실행될 함수 호출
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
                // 화면 떨림 멈춤
                noise.m_AmplitudeGain = 0f;
                noise.m_FrequencyGain = 0f;
            }
        }

        Transform fx1Transfrom = transform.Find("FX_FlameThrower");
        // 우주선뒤에 불 효과 안보이게
        fx1Transfrom.gameObject.SetActive(false);

        // 폭발효과 생성
        ExplosionFx.SetActive(true);

    }
}
