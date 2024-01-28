using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour
{
    public Button[] allButtons;     //�ν����Ϳ��� ��ư������ �ִ°�
    private Button[] buttonObjects; //��ư Instantiate �Ҷ� ���� �迭 

    // Start is called before the first frame update
    void Start()
    {
        ItemCardInstantiate();
    }

    void Update()
    {        
    }

    void ItemCardInstantiate()
    {
        // ��ư ������ ���� �迭 �ʱ�ȭ
        buttonObjects = new Button[3];

        // ��ư ��ġ
        Vector3 buttonPosition = new Vector3();
        // ù��° ��ư ��ġ
        buttonPosition.x = 480;
        buttonPosition.y = 540;

        // ��ư �ߺ������ʵ��� ����2�� �����ؼ� �����ϰ� ������ �ٽ� �̱�
        int button1 =-1, button2=-1;

        // ��ư 3�� ����
        for (int i = 0; i < 3; i++)
        {           
            // 11�� ��ư�߿��� ��������
            int buttonIndex = Random.Range(0, 11);    // 0�̻� 11�̸��� ������
            if(i == 0)
                button1 = buttonIndex;  //ù��° ��ư index ����
            else if(i == 1)
                button2 = buttonIndex;  //�ι�° ��ư index ����
            while (buttonIndex == button1 || buttonIndex == button2)    // ������ �ٽ� �̱�
            { 
                buttonIndex = Random.Range(0, 11);
            }

            // ��ư ������ Instantiate
            buttonObjects[i] = Instantiate(allButtons[buttonIndex], buttonPosition, Quaternion.identity);            
            buttonObjects[i].transform.SetParent(transform);    // ĵ������ �ڽ����� �����ؼ� ȭ�鿡 ���̰�
            buttonPosition.x += 480;                 // ���� ��ư ��ġ ����
        }
    }
    
}
