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
        
        // 3초후 스폰 애니메이션을 실행하는 함수 호출
        StartCoroutine(DelayedFunction());
    }

    void Update()
    {    
        // E누르라는 문구가 떠있을때 E누르면
        if (Input.GetKeyDown(KeyCode.E)&&pressE.gameObject.activeSelf)
        {
            // 문열리는 애니메이션실행
            escapePodAnimator.Play("PodOpen");
            
        }
    }

    IEnumerator DelayedFunction()
    {
        // 1초 대기
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
                // 화면 떨림 멈춤
                noise.m_AmplitudeGain = 0f;
                noise.m_FrequencyGain = 0f;
            }
        }

        Transform fx1Transfrom = transform.Find("FX_FlameThrower");
        // 우주선뒤에 불 효과 안보이게
        fx1Transfrom.gameObject.SetActive(false);

        // 폭발효과 생성
        explosionFx.SetActive(true);

    }
}
