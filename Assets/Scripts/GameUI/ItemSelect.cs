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
        Vector3 buttonPosition = allButtons[0].gameObject.transform.position;
        buttonPosition.x = 480;
        buttonPosition.y = 540;

        for (int i = 0; i < 3; i++)
        {           
            int buttonIndex = Random.Range(0, 5);    // 0이상 5미만의 랜덤값
            // 버튼 프리팹 Instantiate
            buttonObjects[i] = Instantiate(allButtons[buttonIndex], buttonPosition, Quaternion.identity);            
            buttonObjects[i].transform.SetParent(transform);    // 캔버스의 자식으로 설정해서 화면에 보이게
            buttonPosition.x += 480;                 // 다음 버튼 위치 조정
        }
    }

}
