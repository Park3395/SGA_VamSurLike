using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float elapsedTime;   // 경과 시간
    public int currentWave;     // 현재 웨이브
    public float waveDuration;  // wave의 제한시간(초)

    bool waveStarted = false;
    public Canvas pressECanvas;
    public Canvas alarmCanvas;
    public Canvas itemSelectCanvasPrefab;
    public Text alarmText;

    public GameObject[] Wave1Monster;


    void Start()
    {
        // 나중에 주석 풀예정, 게임 패배나 승리시, 아이템 선택시 커서 보이게
        //Cursor.visible = false; // 커서 안보이게
        //Cursor.lockState = CursorLockMode.Locked;   // 커서 안움직이게

        elapsedTime = 0f;       // 경과 시간
        currentWave = 1;        // 현재 웨이브
        waveDuration = 60.0f;   // wave의 제한시간(초)
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&pressECanvas.gameObject.activeSelf)
        {
            pressECanvas.gameObject.SetActive(false);
            // 3초후 첫번째 웨이브 시작하는 함수 호출
            StartCoroutine(FirstWave());
        }
        if(waveStarted)
        {
            elapsedTime += 1.0f * Time.deltaTime;  // 시간 누적
        }

        if (elapsedTime >= waveDuration*currentWave) // 60초가 지나면
        {
            currentWave++;

            StartWave();
        }

        //if ()  //몬스터 다잡으면
        //{
        //    EndWave();
        //}
    }

    IEnumerator FirstWave()
    {
        yield return new WaitForSeconds(3.0f);  // 3초 대기

        // 몬스터 웨이브가 다가옵니다 라고 처음에 적혀있음
        alarmCanvas.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(3.0f);  // 3초 대기
        StartWave();
    }

    void StartWave()
    {
        waveStarted = true;
        alarmText.text = currentWave+"웨이브가 시작됩니다";
        Invoke("HideAlarmCanvas", 3);

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
        alarmCanvas.gameObject.SetActive(false);
        alarmText.text = currentWave + "웨이브 종료!";
        Invoke("HideAlarmCanvas", 3);

        currentWave++;
        waveStarted = false;    // 경과시간 잠시 멈추게됨

        // 인보크로 몇초후에 아이템셀렉트 캔버스 생성함수 불러오기
        Invoke("InstantiateItemSelectCanvas", 3);

        // 아이템 선택이후 다음웨이브 시작
    }

    void HideAlarmCanvas()
    {
        alarmCanvas.gameObject.SetActive(false);
    }

    void InstantiateItemSelectCanvas()
    {
        Canvas itemSelectCanvas = Instantiate(
            itemSelectCanvasPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}