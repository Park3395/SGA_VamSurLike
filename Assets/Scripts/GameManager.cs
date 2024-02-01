using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float elapsedTime;   // ��� �ð�
    public int currentWave;     // ���� ���̺�
    public float waveDuration;  // wave�� ���ѽð�(��)

    bool waveStarted = false;
    public Canvas pressECanvas;
    public Canvas alarmCanvas;
    public Canvas itemSelectCanvasPrefab;
    public Text alarmText;

    public GameObject[] Wave1Monster;


    void Start()
    {
        // ���߿� �ּ� Ǯ����, ���� �й質 �¸���, ������ ���ý� Ŀ�� ���̰�
        //Cursor.visible = false; // Ŀ�� �Ⱥ��̰�
        //Cursor.lockState = CursorLockMode.Locked;   // Ŀ�� �ȿ����̰�

        elapsedTime = 0f;       // ��� �ð�
        currentWave = 1;        // ���� ���̺�
        waveDuration = 60.0f;   // wave�� ���ѽð�(��)
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&pressECanvas.gameObject.activeSelf)
        {
            pressECanvas.gameObject.SetActive(false);
            // 3���� ù��° ���̺� �����ϴ� �Լ� ȣ��
            StartCoroutine(FirstWave());
        }
        if(waveStarted)
        {
            elapsedTime += 1.0f * Time.deltaTime;  // �ð� ����
        }

        if (elapsedTime >= waveDuration*currentWave) // 60�ʰ� ������
        {
            currentWave++;

            StartWave();
        }

        //if ()  //���� ��������
        //{
        //    EndWave();
        //}
    }

    IEnumerator FirstWave()
    {
        yield return new WaitForSeconds(3.0f);  // 3�� ���

        // ���� ���̺갡 �ٰ��ɴϴ� ��� ó���� ��������
        alarmCanvas.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(3.0f);  // 3�� ���
        StartWave();
    }

    void StartWave()
    {
        waveStarted = true;
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
                }
            }
        }
        
    }

    void EndWave()
    {
        alarmCanvas.gameObject.SetActive(false);
        alarmText.text = currentWave + "���̺� ����!";
        Invoke("HideAlarmCanvas", 3);

        currentWave++;
        waveStarted = false;    // ����ð� ��� ���߰Ե�

        // �κ�ũ�� �����Ŀ� �����ۼ���Ʈ ĵ���� �����Լ� �ҷ�����
        Invoke("InstantiateItemSelectCanvas", 3);

        // ������ �������� �������̺� ����
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