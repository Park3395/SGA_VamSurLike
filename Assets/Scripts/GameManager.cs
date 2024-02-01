using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float elapsedTime;   // ��� �ð�
    public int currentWave;     // ���� ���̺�
    public float waveDuration;  // wave�� ���ѽð�(��)

    bool waveStarted = false;
    public Canvas pressECanvas;

    public GameObject[] Wave1Monster;


    void Start()
    {
        // ���߿� �ּ� Ǯ����
        //Cursor.visible = false; // Ŀ�� �Ⱥ��̰�
        //Cursor.lockState = CursorLockMode.Locked;   // Ŀ�� �ȿ����̰�

        elapsedTime = 0f;
        currentWave = 1;
        waveDuration = 60.0f;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&pressECanvas.gameObject.activeSelf)
        {
            waveStarted = true;
            
            // 3���� ù��° ���̺� �����ϴ� �Լ� ȣ��
            StartCoroutine(FirstWave());
        }
        if(waveStarted)
        {
            elapsedTime += 1.0f * Time.deltaTime;  // �ð� ����
        }

        if (elapsedTime >= waveDuration) // 60�ʰ� ������
        {
            currentWave++;

            elapsedTime = 0f;
            StartWave();
        }

        //if (elapsedTime >= waveDuration * 60f)  //���� ��������
        //{
        //    EndWave();
        //}
    }

    IEnumerator FirstWave()
    {
        yield return new WaitForSeconds(3.0f);  // 3�� ���
        Debug.Log("3���Ŀ� ���̺갡 ���۵˴ϴ�");
        // 5���Ŀ� wave�� ���۵˴ϴ� ��� text����
        
        yield return new WaitForSeconds(3.0f);  // 3�� ���
        StartWave();
    }
    void StartWave()
    {
        Debug.Log(currentWave + "Wave�� ���۵˴ϴ�");
        
        waveStarted = true;

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
}