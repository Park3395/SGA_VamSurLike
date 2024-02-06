using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour
{
    public Button[] allButtons;     //�ν����Ϳ��� ��ư������ �ִ°�
    private Button[] buttonObjects; //��ư Instantiate �Ҷ� ���� �迭 
    public GameObject ItemSelectCanvas; // destroy�� ĵ����
    private PlayerStat playerStat;

    //List<string> itemIndices = new List<string>(); //������ ��������� �����ϴ� ����Ʈ
    // ���ӸŴ��� ��ũ��Ʈ ��������
    private GameManager gameManagerInstance;

    void Start()
    {
        ItemButtonInstantiate();
    }

    void Update()
    {
    }

    void ItemButtonInstantiate()
    {
        // ��ư ������ ���� �迭 �ʱ�ȭ
        buttonObjects = new Button[3];

        // ��ư ��ġ
        Vector3 buttonPosition = new Vector3();
        // ù��° ��ư ��ġ
        buttonPosition.x = 480;
        buttonPosition.y = 480;

        // �ߺ����� ���� ������ ��ư �ε����� ������ ����Ʈ
        List<int> uniqueIndices = new List<int>();

        // ��ư 3�� ����
        for (int i = 0; i < 3; i++)
        {
            int buttonIndex;

            // �ߺ����� ���� ������ �ε��� ã��
            do
            {
                buttonIndex = UnityEngine.Random.Range(0, 10);
            } while (uniqueIndices.Contains(buttonIndex));

            // ã�� �ε����� ����Ʈ�� �߰�
            uniqueIndices.Add(buttonIndex);

            // ��ư ������ Instantiate
            buttonObjects[i] = Instantiate(allButtons[buttonIndex],
                buttonPosition, Quaternion.identity);
            // ĵ������ �ڽ����� �����ؼ� ȭ�鿡 ���̰�
            buttonObjects[i].transform.SetParent(transform);    
            buttonPosition.x += 480;    // ���� ��ư ��ġ ����
        }
    }

    public void ButtonAttackPower()
    {
        // ���ӸŴ����� �ִ� ����Ʈ�� ������ �������ߴ��� ����
        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add("Dmg");
        // �÷��̾� ���� ��ũ��Ʈ�� ���� ����
        playerStat = PlayerStat.instance;
        playerStat.Dmg += 5;
        // ������ ���� ĵ���� ���ֱ�
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        // �ð��帧 �ٽ� �ǵ�����
        Time.timeScale = 1;
    }
    public void ButtonAttackSpeed()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add("AttSpd");
        playerStat = PlayerStat.instance;
        playerStat.AttSpd += 0.1f;
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
    }
    public void ButtonCriticalPower()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add("Cridmg");
        playerStat = PlayerStat.instance;
        playerStat.Cridmg += 0.2f;
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
    }
    public void ButtonCriticalProbability()
    {
        gameManagerInstance = FindObjectOfType<GameManager>(); 
        gameManagerInstance.itemIndices.Add("Cri");
        playerStat = PlayerStat.instance;
        playerStat.Cri += 0.15f;
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
    }
    public void ButtonDoubleJump()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add("JumpCount");
        playerStat = PlayerStat.instance;
        playerStat.JumpCount += 1;
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
    }
    public void ButtonHpRegen()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add("HPregen");
        playerStat = PlayerStat.instance;
        playerStat.HPregen += 1;
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
    }
    public void ButtonJumpPower()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add("Jump");
        playerStat = PlayerStat.instance;
        playerStat.Jump += 0.1f;
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
    }
    public void ButtonMaxHp()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add("MaxHP");
        playerStat = PlayerStat.instance;
        playerStat.MaxHP += 10;  
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
    }
    public void ButtonMoveSpeed()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add("Speed");
        playerStat = PlayerStat.instance;
        playerStat.Speed += 3;
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
    }
    public void ButtonShield()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add("Barrier");
        playerStat = PlayerStat.instance;
        playerStat.Barrier += 10;
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
    }
}
