using Cinemachine;
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
    public Canvas WinCanvasPrefab;
    public Text alarmText;
    public Text clockText;
    public GameObject player;

    string time;
    public int sec;
    public int leftSec;
    public int monsterKillAmount;
    public int totalElapsedTime;
    public int currentWave;        // ���� ���̺�
    public float elapsedTime;      // ��� �ð�
    int playerHP;

    bool waveStarted;
    bool gameOver;
    bool itemSelected;

    public CinemachineVirtualCamera virtualCamerainGameManager;

    Canvas itemSelectCanvas;    // instantiate�� ������ ��ü

    // ��������ִ� ���͸� ������ ����Ʈ
    private List<GameObject> currentWaveMonsters = new List<GameObject>();
    public GameObject[] Wave1Monster;
    public GameObject[] Wave2Monster;
    public GameObject[] Wave3Monster;

    public List<string> itemIndices = new List<string>(); //������ ��������� �����ϴ� ����Ʈ

    void Start()
    {
        // ���߿� �ּ� Ǯ����, ���� �й質 �¸���, ������ ���ý� Ŀ�� ���̰�
        Cursor.visible = false; // Ŀ�� �Ⱥ��̰�
        Cursor.lockState = CursorLockMode.Locked;   // Ŀ�� �ȿ����̰�

        elapsedTime = 0f;       // ��� �ð�
        currentWave = 1;        // ���� ���̺�

        totalElapsedTime = 0;
        monsterKillAmount = 0;
        waveStarted = false;
        gameOver = false;
        itemSelected = false;
    }


    void Update()
    {
        // �ð�
        int totalSeconds = (int)elapsedTime;    // 1.234567 ���Ŀ��� �Ҽ����ڸ� ����
        sec = totalSeconds % 61;
        leftSec = 60 - sec;
        time = leftSec.ToString("00");
        clockText.text = time;

        playerHP = player.GetComponent<PlayerStat>().NowHP;
        if (playerHP <= 0 && !gameOver)
        {
            gameOver = true;
            totalElapsedTime += totalSeconds;
            waveStarted = false;

            // �״¾ִϸ��̼� �ֱ�
            player.gameObject.SetActive(false);

            Invoke("InstantiateLoseCanvas", 3);
        }

        if (Input.GetKeyDown(KeyCode.E) && pressECanvas.gameObject.activeSelf)
        {
            pressECanvas.gameObject.SetActive(false);
            // �÷��̾� Ȱ��ȭ
            player.SetActive(true);

            // ����ī�޶� ��Ȱ��ȭ
            virtualCamerainGameManager = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
            if (virtualCamerainGameManager != null)
            {
                virtualCamerainGameManager.gameObject.SetActive(false);
            }
            // ù���̺� ����
            StartCoroutine(FirstWave());
        }

        if (waveStarted)
        {
            elapsedTime += 1.0f * Time.deltaTime;  // �ð� ����
        }

        if (sec == 60) // ���͸���� 60�ʰ� ������
        {
            currentWave++;
            StartWave();
        }

        if (IsMonsterDead() && waveStarted)  //���� ��������
        {
            EndWave();
        }

        if (KilledMonsterAmount() % 4 == 1 && !itemSelected)
        {
            Time.timeScale = 0;
            // ������ ���� ĵ���� ����
            itemSelectCanvas = Instantiate(itemSelectCanvasPrefab,
                new Vector3(0, 0, 0), Quaternion.identity);
            itemSelected = true;

        }
        if (KilledMonsterAmount() % 4 == 3)
        {
            itemSelected = false;
        }

        if (KilledMonsterAmount() == 17 && !gameOver)
        {
            gameOver = true;
            Destroy(alarmCanvas);
            Invoke("InstantiateWinCanvas", 3);
        }

    }

    public void StartWave()
    {        
        waveStarted = true;
        totalElapsedTime += sec;
        elapsedTime = 0f;
        clockText.gameObject.SetActive(true);
        alarmCanvas.gameObject.SetActive(true);
        alarmText.text = currentWave+"���̺갡 ���۵˴ϴ�";
        Invoke("HideAlarmCanvas", 3);

        // ���̺꿡���� �� ���� 
        if (currentWave ==1)
        {
            if (Wave1Monster != null)
            {
                foreach (GameObject obj in Wave1Monster)
                {
                    //�̸� ��ġ�� ��Ȱ��ȭ�� ���� Ȱ��ȭ
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
        if (currentWave == 3)
        {
            if (Wave3Monster != null)
            {
                foreach (GameObject obj in Wave3Monster)
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

    public void InstantiateItemSelectCanvas()
    {
        itemSelectCanvas = Instantiate(itemSelectCanvasPrefab,
                new Vector3(0, 0, 0), Quaternion.identity);
    }

    void InstantiateLoseCanvas()
    {
        Canvas loseCanvas = Instantiate(loseCanvasPrefab,
            new Vector3(0, 0, 0), Quaternion.identity);
    }

    void InstantiateWinCanvas()
    {
        // ȭ��ȿ����̰� ����ī�޶��������
        virtualCamerainGameManager.gameObject.SetActive(true);
        Canvas winCanvas = Instantiate(WinCanvasPrefab,
            new Vector3(0, 0, 0), Quaternion.identity);
    }

    bool IsMonsterDead()
    {
        // ���� ���̺꿡 ���� ���͵��� ��� �׾����� ���θ� Ȯ��
        foreach (GameObject monster in currentWaveMonsters)
        {
            // ���Ͱ� �ϳ��� Ȱ��ȭ�Ǿ� ������ false��ȯ
            if (monster.gameObject.activeSelf == true)
            {
                return false;
            }            
        }

        // ���� ���̺꿡 ���� ���͵��� ��� �׾��ٸ� true ��ȯ
        return true;
    }

    int KilledMonsterAmount()
    {
        monsterKillAmount = 0;
        foreach (GameObject monster in currentWaveMonsters)
        {
            if (!monster.activeSelf)
            {
                monsterKillAmount++;
            }
        }
        return monsterKillAmount;
    }
}