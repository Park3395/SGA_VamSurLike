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
        Vector3 buttonPosition = allButtons[0].gameObject.transform.position;
        buttonPosition.x = 480;
        buttonPosition.y = 540;

        for (int i = 0; i < 3; i++)
        {           
            int buttonIndex = Random.Range(0, 5);    // 0�̻� 5�̸��� ������
            // ��ư ������ Instantiate
            buttonObjects[i] = Instantiate(allButtons[buttonIndex], buttonPosition, Quaternion.identity);            
            buttonObjects[i].transform.SetParent(transform);    // ĵ������ �ڽ����� �����ؼ� ȭ�鿡 ���̰�
            buttonPosition.x += 480;                 // ���� ��ư ��ġ ����
        }
    }

}
