using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsContents : MonoBehaviour
{
    // 텍스트 인스펙터에 넣을곳
    public Text timeNumber;
    public Text killNumber;
    public Text damageNumber;
    public Text damagedNumber;
    public Text waveNumber;
    public Text itemAmountNumber;

    public Text timeScore;
    public Text killScore;
    public Text damageScore;
    public Text damagedScore;
    public Text waveScore;
    public Text itemAmountScore;
    public Text totalScore;

    // 생존한 시간 가져올 변수
    public int aliveTime;
    // 게임매니저 스크립트 가져오기
    private GameManager gameManagerInstance;

    int min;
    int sec;
    string time;

    void Start()
    {
        Cursor.visible = true; // 커서 보이게
        Cursor.lockState = CursorLockMode.None;   // 커서 움직이게

        gameManagerInstance = FindObjectOfType<GameManager>();
        
        // 게임매니저에서 가져오기
        int totalSeconds = gameManagerInstance.totalElapsedTime;
        min = totalSeconds / 60;
        sec = totalSeconds % 60;
        time = min.ToString() + ":" + sec.ToString("00");
        timeNumber.text = time;
        timeScore.text = (totalSeconds * 6).ToString();

        int getwave = gameManagerInstance.currentWave;
        waveNumber.text = getwave.ToString();
        waveScore.text = (getwave * 100).ToString();

        int killAmount = gameManagerInstance.monsterKillAmount;
        killNumber.text = killAmount.ToString();
        killScore.text = (killAmount * 10).ToString();

        itemAmountNumber.text = gameManagerInstance.itemIndices.Count.ToString();
        itemAmountScore.text = (gameManagerInstance.itemIndices.Count*110).ToString();

        //damageScore.text;
        //damagedScore.text;

        totalScore.text = (totalSeconds * 6 + getwave * 100 + killAmount * 10
            + gameManagerInstance.itemIndices.Count * 110).ToString();

    }

    void Update()
    {
        
    }
}
