using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsContents : MonoBehaviour
{
    // 텍스트 인스펙터에 넣을곳
    public Text textAlive;
    // 생존한 시간 가져올 변수
    public int aliveTime;
    // 게임매니저 스크립트 가져오기
    private GameManager gameManagerInstance;

    public Text timeScoreText;

    int min;
    int sec;
    string time;

    void Start()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        min = 1;

        //float getTime = gameManagerInstance.elapsedTime;
        //time = (getTime / 60).ToString() + ":" + (getTime % 60).ToString("00");
        //textAlive.text = time;

    }


    void Update()
    {
        float getTime = gameManagerInstance.elapsedTime;
        int totalSeconds = (int)getTime;
        min = totalSeconds / 60;
        sec = totalSeconds % 60;
        time = min.ToString() + ":" + sec.ToString("00");
        textAlive.text = time;
        timeScoreText.text = (totalSeconds * 6).ToString();
    }
}
