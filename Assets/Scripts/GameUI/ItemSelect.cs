using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour
{
    public Button[] allButtons;     //인스펙터에서 버튼프리팹 넣는곳
    private Button[] buttonObjects; //버튼 Instantiate 할때 쓰는 배열 

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
        // 버튼 프리팹 넣을 배열 초기화
        buttonObjects = new Button[3];

        // 버튼 위치
        Vector3 buttonPosition = new Vector3();
        // 첫번째 버튼 위치
        buttonPosition.x = 480;
        buttonPosition.y = 540;

        // 버튼 중복되지않도록 변수2개 생성해서 저장하고 같으면 다시 뽑기
        int button1 =-1, button2=-1;

        // 버튼 3개 생성
        for (int i = 0; i < 3; i++)
        {           
            // 11개 버튼중에서 랜덤으로
            int buttonIndex = Random.Range(0, 11);    // 0이상 11미만의 랜덤값
            if(i == 0)
                button1 = buttonIndex;  //첫번째 버튼 index 저장
            else if(i == 1)
                button2 = buttonIndex;  //두번째 버튼 index 저장
            while (buttonIndex == button1 || buttonIndex == button2)    // 같으면 다시 뽑기
            { 
                buttonIndex = Random.Range(0, 11);
            }

            // 버튼 프리팹 Instantiate
            buttonObjects[i] = Instantiate(allButtons[buttonIndex], buttonPosition, Quaternion.identity);            
            buttonObjects[i].transform.SetParent(transform);    // 캔버스의 자식으로 설정해서 화면에 보이게
            buttonPosition.x += 480;                 // 다음 버튼 위치 조정
        }
    }
    
}
