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
            virtualCamera.enabled = false;
            // 플레이어 활성화
            player.SetActive(true);
        }
    }

    IEnumerator DelayedFunction()
    {
        // 2초 대기
        yield return new WaitForSeconds(2.0f);
        // 2초 후에 실행될 함수 호출
        animator.Play("PodSpawn");        

    }
}
