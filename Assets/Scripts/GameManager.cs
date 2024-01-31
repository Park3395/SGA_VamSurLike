using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float elapsedTime;   // 경과 시간
    public int currentWave;    // 현재 웨이브
    public float waveDuration;  // wave의 제한시간(초)

    bool waveStarted = false;
    public Canvas pressECanvas;

    public GameObject[] Wave1Monster;


    void Start()
    {
        // 나중에 주석 풀예정
        //Cursor.visible = false; // 커서 안보이게
        //Cursor.lockState = CursorLockMode.Locked;   // 커서 안움직이게

        elapsedTime = 0f;
        currentWave = 1;
        waveDuration = 60.0f;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&pressECanvas.gameObject.activeSelf)
        {
            waveStarted = true;
            
            // 3초후 첫번째 웨이브 시작하는 함수 호출
            StartCoroutine(FirstWave());
        }
        if(waveStarted)
        {
            elapsedTime += 1.0f * Time.deltaTime;  // 시간 누적
        }

        if (elapsedTime >= waveDuration) // 60초가 지나면
        {
            currentWave++;

            elapsedTime = 0f;
            StartWave();
        }

        //if (elapsedTime >= waveDuration * 60f)  //몬스터 다잡으면
        //{
        //    EndWave();
        //}
    }

    IEnumerator FirstWave()
    {
        yield return new WaitForSeconds(3.0f);  // 3초 대기
        Debug.Log("3초후에 웨이브가 시작됩니다");
        // 5초후에 wave가 시작됩니다 라고 text띄우기
        
        yield return new WaitForSeconds(3.0f);  // 3초 대기
        StartWave();
    }
    void StartWave()
    {
        Debug.Log(currentWave + "Wave가 시작됩니다");
        
        waveStarted = true;

        // 적 생성 프리팹 비활성화된거 웨이브에따라 활성화, 애니메이션실행
        if(currentWave ==1)
        {
            if (Wave1Monster != null)
            {
                foreach (GameObject obj in Wave1Monster)
                {
                    obj.SetActive(true);
                }
            }
        }
        
    }

    void EndWave()
    {
        Debug.Log("1웨이브 종료!");
        // 웨이브 초기화 또는 다음 웨이브 설정 등의 작업 수행
        currentWave++;
        // 변수 초기화
        elapsedTime = 0f;
        waveStarted = false;

        // 코루틴으로? 몇초후에 아이템셀렉트 생성함수 불러오기
        // 아이템 선택이후 다음웨이브 시작
    }
}