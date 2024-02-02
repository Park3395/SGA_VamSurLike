using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
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
        gameManagerInstance = FindObjectOfType<GameManager>();

        // 캔버스 instantiate할때 계산되도록 Update있는내용 Start에

    }


    void Update()
    {        
        float getTime = gameManagerInstance.elapsedTime;    // 게임매니저에서 가져오기
        int totalSeconds = (int)getTime;                    // 1.23456 형식 소숫점자리 버림
        min = totalSeconds / 60;
        sec = totalSeconds % 60;
        time = min.ToString() + ":" + sec.ToString("00");
        timeNumber.text = time;
        timeScore.text = (totalSeconds * 6).ToString();

        int getwave = gameManagerInstance.currentWave;
        waveNumber.text = getwave.ToString();

        //killScore.text;
        //damageScore.text;
        //damagedScore.text;
        waveScore.text = (getwave * 100).ToString();
        //itemAmountScore.text;
        //totalScore.text=(totalSeconds * 6+getwave * 100).ToString();
    }
}
