using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsContents : MonoBehaviour
{
    // �ؽ�Ʈ �ν����Ϳ� ������
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

    // ������ �ð� ������ ����
    public int aliveTime;
    // ���ӸŴ��� ��ũ��Ʈ ��������
    private GameManager gameManagerInstance;

    int min;
    int sec;
    string time;

    void Start()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();

        // ĵ���� instantiate�Ҷ� ���ǵ��� Update�ִ³��� Start��

    }


    void Update()
    {        
        float getTime = gameManagerInstance.elapsedTime;    // ���ӸŴ������� ��������
        int totalSeconds = (int)getTime;                    // 1.23456 ���� �Ҽ����ڸ� ����
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
