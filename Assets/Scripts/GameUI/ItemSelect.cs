using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour
{
    public Button[] allButtons;     //�ν����Ϳ��� ��ư������ �ִ°�
    private Button[] buttonObjects; //��ư Instantiate �Ҷ� ���� �迭 
    public GameObject ItemSelectCanvas; // destroy�� ĵ����

    private GameManager gameManagerInstance;

    void Start()
    {
        ItemButtonInstantiate();
        gameManagerInstance = FindObjectOfType<GameManager>();

        //ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect");
        //if (ItemSelectCanvas == null)
        //{
        //    Debug.Log("ItemSelectCanvas�� ã�� �� �����ϴ�.");
        //}
        //else
        //    Debug.Log("ItemSelectCanvas�� ã�ҽ��ϴ�.");

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
                buttonIndex = Random.Range(0, 11);
            } while (uniqueIndices.Contains(buttonIndex));

            // ã�� �ε����� ����Ʈ�� �߰�
            uniqueIndices.Add(buttonIndex);

            // ��ư ������ Instantiate
            buttonObjects[i] = Instantiate(allButtons[buttonIndex], buttonPosition, Quaternion.identity);
            buttonObjects[i].transform.SetParent(transform);    // ĵ������ �ڽ����� �����ؼ� ȭ�鿡 ���̰�
            buttonPosition.x += 480;                 // ���� ��ư ��ġ ����
        }
    }

    public void ButtonArmorPower()
    {
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
    }
    public void ButtonAttackPower()
    {
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
    }
    public void ButtonAttackSpeed()
    {
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
    }
    public void ButtonCriticalPower()
    {
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
    }
    public void ButtonCriticalProbability()
    {
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
    }
    public void ButtonDoubleJump()
    {
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
    }
    public void ButtonHpRegen()
    {
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
    }
    public void ButtonJumpPower()
    {
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
    }
    public void ButtonMaxHp()
    {
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
    }
    public void ButtonMoveSpeed()
    {
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
    }
    public void ButtonShield()
    {
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
    }
}
