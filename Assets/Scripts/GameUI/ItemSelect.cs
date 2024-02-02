using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour
{
    public Button[] allButtons;     //�ν����Ϳ��� ��ư������ �ִ°�
    private Button[] buttonObjects; //��ư Instantiate �Ҷ� ���� �迭 

    private GameManager gameManagerInstance;

    void Start()
    {
        ItemButtonInstantiate();
        gameManagerInstance = FindObjectOfType<GameManager>();

        if (gameManagerInstance == null)
        {
            Debug.LogError("GameManager�� ã�� �� �����ϴ�.");
        }
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
        for (int i = 0;i < 3;i++)
        {
            Destroy(buttonObjects[i]);
        }
        gameManagerInstance.StartWave();
    }
    public void ButtonAttackPower()
    {

        gameManagerInstance.StartWave();
    }
    public void ButtonAttackSpeed()
    {

        gameManagerInstance.StartWave();
    }
    public void ButtonCriticalPower()
    {

        gameManagerInstance.StartWave();
    }
    public void ButtonCriticalProbability()
    {

        gameManagerInstance.StartWave();
    }
    public void ButtonDoubleJump()
    {

        gameManagerInstance.StartWave();
    }
    public void ButtonHpRegen()
    {

        gameManagerInstance.StartWave();
    }
    public void ButtonJumpPower()
    {

        gameManagerInstance.StartWave();
    }
    public void ButtonMaxHp()
    {

        gameManagerInstance.StartWave();
    }
    public void ButtonMoveSpeed()
    {

        gameManagerInstance.StartWave();
    }
    public void ButtonShield()
    {

        gameManagerInstance.StartWave();
    }
}
