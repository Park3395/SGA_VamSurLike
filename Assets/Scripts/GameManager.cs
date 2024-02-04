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
    public int monsterKillAmount;   // ������ 0���� ����� ++ ���� ��ũ��Ʈ����
    public int totalElapsedTime;
    public int currentWave;     // ���� ���̺�
    public float elapsedTime;   // ��� �ð�
    int playerHP;

    bool waveStarted;
    bool gameOver;

    //Canvas itemSelectCanvas;    // instantiate�� ������ ��ü

    // ��������ִ� ���͸� ������ ����Ʈ
    private List<GameObject> currentWaveMonsters = new List<GameObject>();
    public GameObject[] Wave1Monster;
    public GameObject[] Wave2Monster;


    void Start()
    {
        // ���߿� �ּ� Ǯ����, ���� �й質 �¸���, ������ ���ý� Ŀ�� ���̰�
        //Cursor.visible = false; // Ŀ�� �Ⱥ��̰�
        //Cursor.lockState = CursorLockMode.Locked;   // Ŀ�� �ȿ����̰�

        elapsedTime = 0f;       // ��� �ð�
        currentWave = 1;        // ���� ���̺�

        totalElapsedTime = 0;
        waveStarted = false;
        gameOver = false;
    }


    void Update()
    {
        // �ð�
        int totalSeconds = (int)elapsedTime;    // 1.23456 ���� �Ҽ����ڸ� ����
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

            // �״¾ִϸ��̼�
            player.gameObject.SetActive(false);

            Invoke("InstantiateLoseCanvas", 3);
        }

        if (Input.GetKeyDown(KeyCode.E)&&pressECanvas.gameObject.activeSelf)
        {
            pressECanvas.gameObject.SetActive(false);
            // �÷��̾� Ȱ��ȭ
            player.SetActive(true);
            // 3���� ù��° ���̺� �����ϴ� �Լ� ȣ��
            StartCoroutine(FirstWave());
        }

        if(waveStarted)
        {
            elapsedTime += 1.0f * Time.deltaTime;  // �ð� ����
        }

        if (sec==60) // ���͸���� 60�ʰ� ������
        {
            currentWave++;
            StartWave();
        }

        if (IsMonsterDead()&&waveStarted)  //���� ��������
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
        alarmText.text = currentWave+"���̺갡 ���۵˴ϴ�";
        Invoke("HideAlarmCanvas", 3);

        // �� ���� ������ ��Ȱ��ȭ�Ȱ� ���̺꿡���� Ȱ��ȭ, �ִϸ��̼ǽ���
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
        alarmText.text = currentWave + "���̺� ����!";

        currentWave++;
        waveStarted = false;    // ����ð� ����

        // 3���� �������̺� ���� 
        Invoke("StartWave", 5);
    }

    IEnumerator FirstWave()
    {
        yield return new WaitForSeconds(3.0f);  // 3�� ���

        // ���� ���̺갡 �ٰ��ɴϴ� ��� ó���� ��������
        alarmCanvas.gameObject.SetActive(true);

        yield return new WaitForSeconds(3.0f);  // 3�� ���
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
        // ���� ���̺꿡 ���� ���͵��� ��� �׾����� ���θ� Ȯ��
        foreach (GameObject monster in currentWaveMonsters)
        {
            // ���Ͱ� �ϳ��� Ȱ��ȭ�Ǿ� ������ false��ȯ
            //if (monster.gameObject.activeSelf==true)
            //{
            //    return false;
            //}
            // ���� ������ destroy �ϰ��
            if(monster != null)
            {
                return false;
            }
        }

        // ���� ���̺꿡 ���� ���͵��� ��� �׾��ٸ� true ��ȯ
        return true;
    }
}