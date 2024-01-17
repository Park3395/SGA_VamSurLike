using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    // 회전 속도
    [SerializeField]
    float rotSpeed = 1000f;

    // 마우스 수평 이동 처리
    float mx;
    // 마우스 수직 이동 처리
    float my;

    private void Update()
    {
        // 마우스 수평 입력
        float mouseX = Input.GetAxis("Mouse X");
        // 마우스 수직 입력
        float mouseY = Input.GetAxis("Mouse Y");

        // 마우스 입력과 회전속도 연산
        mx += mouseX * rotSpeed * Time.deltaTime;
        my += mouseY * rotSpeed * Time.deltaTime;

        // 카메라 수직 회전 최소,최대값 설정
        my = Mathf.Clamp(my, -90f, 30f);
        
        // 카메라 회전
        transform.eulerAngles = new Vector3(my, mx, 0);
    }
}
