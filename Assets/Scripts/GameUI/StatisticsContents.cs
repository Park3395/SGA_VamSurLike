using System.Collections;
using System.Collections.Generic;
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
        Cursor.visible = true; // Ŀ�� ���̰�
        Cursor.lockState = CursorLockMode.None;   // Ŀ�� �����̰�

        gameManagerInstance = FindObjectOfType<GameManager>();
        
        // ���ӸŴ������� ��������
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
