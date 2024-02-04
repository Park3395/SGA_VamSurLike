using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas pressECanvas;
    public Canvas alarmCanvas;
    public Canvas itemSelectCanvasPrefab;
    public Canvas loseCanvasPrefab;
    public Text alarmText;
    public Text clockText;
    public GameObject player;

    string time;
    public int sec;
    public int leftSec;
    public int monsterKillAmount;   // 몬스터피 0으로 만들면 ++ 몬스터 스크립트에서
    public int totalElapsedTime;
    public int currentWave;     // 현재 웨이브
    public float elapsedTime;   // 경과 시간
    int playerHP;

    bool waveStarted;
    bool gameOver;

    //Canvas itemSelectCanvas;    // instantiate로 생성된 객체

    // 현재까지있는 몬스터를 저장할 리스트
    private List<GameObject> currentWaveMonsters = new List<GameObject>();
    public GameObject[] Wave1Monster;
    public GameObject[] Wave2Monster;


    void Start()
    {
        // 나중에 주석 풀예정, 게임 패배나 승리시, 아이템 선택시 커서 보이게
        //Cursor.visible = false; // 커서 안보이게
        //Cursor.lockState = CursorLockMode.Locked;   // 커서 안움직이게

        elapsedTime = 0f;       // 경과 시간
        currentWave = 1;        // 현재 웨이브

        totalElapsedTime = 0;
        waveStarted = false;
        gameOver = false;
    }


    void Update()
    {
        // 시간
        int totalSeconds = (int)elapsedTime;    // 1.23456 형식 소숫점자리 버림
        sec = totalSeconds % 61;
        leftSec = 60 - sec;
        time = leftSec.ToString("00");
        clockText.text = time;

        playerHP = player.GetComponent<PlayerStat>().NowHP;
        if(playerHP <= 0 && !gameOver)
        {
            gameOver = true;
            totalElapsedTime += totalSeconds;
            waveStarted = false;

            // 죽는애니메이션
            player.gameObject.SetActive(false);

            Invoke("InstantiateLoseCanvas", 3);
        }

        if (Input.GetKeyDown(KeyCode.E)&&pressECanvas.gameObject.activeSelf)
        {
            pressECanvas.gameObject.SetActive(false);
            // 플레이어 활성화
            player.SetActive(true);
            // 3초후 첫번째 웨이브 시작하는 함수 호출
            StartCoroutine(FirstWave());
        }

        if(waveStarted)
        {
            elapsedTime += 1.0f * Time.deltaTime;  // 시간 누적
        }

        if (sec==60) // 몬스터못잡고 60초가 지나면
        {
            currentWave++;
            StartWave();
        }

        if (IsMonsterDead()&&waveStarted)  //몬스터 다잡으면
        {
            EndWave();
        }
        
    }

    public void StartWave()
    {        
        waveStarted = true;
        totalElapsedTime += sec;
        elapsedTime = 0f;
        clockText.gameObject.SetActive(true);
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
                    currentWaveMonsters.Add(obj);
                }
            }
        }
        if (currentWave == 2)
        {
            if (Wave2Monster != null)
            {
                foreach (GameObject obj in Wave2Monster)
                {
                    obj.SetActive(true);
                    currentWaveMonsters.Add(obj);
                }
            }
        }

    }

    public void EndWave()
    {
        alarmCanvas.gameObject.SetActive(true);
        alarmText.text = currentWave + "웨이브 종료!";

        currentWave++;
        waveStarted = false;    // 경과시간 멈춤

        // 3초후 다음웨이브 시작 
        Invoke("StartWave", 5);
    }

    IEnumerator FirstWave()
    {
        yield return new WaitForSeconds(3.0f);  // 3초 대기

        // 몬스터 웨이브가 다가옵니다 라고 처음에 적혀있음
        alarmCanvas.gameObject.SetActive(true);

        yield return new WaitForSeconds(3.0f);  // 3초 대기
        StartWave();
    }

    void HideAlarmCanvas()
    {
        alarmCanvas.gameObject.SetActive(false);
    }

    //void InstantiateItemSelectCanvas()
    //{
    //    itemSelectCanvas = Instantiate(itemSelectCanvasPrefab,
    //        new Vector3(0, 0, 0), Quaternion.identity);
    //}
    
    //public void DestroyItemSelectCanvas()
    //{
    //    Destroy(itemSelectCanvas);
    //}

    void InstantiateLoseCanvas()
    {
        Canvas loseCanvas = Instantiate(loseCanvasPrefab,
            new Vector3(0, 0, 0), Quaternion.identity);
    }

    bool IsMonsterDead()
    {
        // 현재 웨이브에 속한 몬스터들이 모두 죽었는지 여부를 확인
        foreach (GameObject monster in currentWaveMonsters)
        {
            // 몬스터가 하나라도 활성화되어 있으면 false반환
            //if (monster.gameObject.activeSelf==true)
            //{
            //    return false;
            //}
            // 몬스터 죽으면 destroy 일경우
            if(monster != null)
            {
                return false;
            }
        }

        // 현재 웨이브에 속한 몬스터들이 모두 죽었다면 true 반환
        return true;
    }
}