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
    public Text alarmText;

    public GameObject[] Wave1Monster;


    void Start()
    {
        // ���߿� �ּ� Ǯ����, ���� �й質 �¸��� Ŀ�� ���̰�
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
            waveStarted = true;
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

        // ���� ���̺갡 �ٰ��ɴϴ� ��� text����
        alarmCanvas.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(3.0f);  // 3�� ���
        StartWave();
        //alarmText.text = "���̺갡 ���۵˴ϴ�";
    }

    void StartWave()
    {
        waveStarted = true;
        //Debug.Log(currentWave + "Wave�� ���۵˴ϴ�");
        alarmText.text = currentWave+"���̺갡 ���۵˴ϴ�";
        Invoke("HideCanvas", 3);

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
        Debug.Log("1���̺� ����!");
        // ���̺� �ʱ�ȭ �Ǵ� ���� ���̺� ���� ���� �۾� ����
        currentWave++;
        // ���� �ʱ�ȭ
        elapsedTime = 0f;
        waveStarted = false;

        // �ڷ�ƾ����? �����Ŀ� �����ۼ���Ʈ �����Լ� �ҷ�����
        // ������ �������� �������̺� ����
    }

    void HideCanvas()
    {
        alarmCanvas.gameObject.SetActive(false);
    }
}