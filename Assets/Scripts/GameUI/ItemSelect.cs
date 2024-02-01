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
        ItemButtonInstantiate();
    }

    void Update()
    {
    }

    void ItemButtonInstantiate()
    {
        // 버튼 프리팹 넣을 배열 초기화
        buttonObjects = new Button[3];

        // 버튼 위치
        Vector3 buttonPosition = new Vector3();
        // 첫번째 버튼 위치
        buttonPosition.x = 480;
        buttonPosition.y = 480;

        // 중복되지 않은 랜덤한 버튼 인덱스를 저장할 리스트
        List<int> uniqueIndices = new List<int>();

        // 버튼 3개 생성
        for (int i = 0; i < 3; i++)
        {
            int buttonIndex;

            // 중복되지 않은 랜덤한 인덱스 찾기
            do
            {
                buttonIndex = Random.Range(0, 11);
            } while (uniqueIndices.Contains(buttonIndex));

            // 찾은 인덱스를 리스트에 추가
            uniqueIndices.Add(buttonIndex);

            // 버튼 프리팹 Instantiate
            buttonObjects[i] = Instantiate(allButtons[buttonIndex], buttonPosition, Quaternion.identity);
            buttonObjects[i].transform.SetParent(transform);    // 캔버스의 자식으로 설정해서 화면에 보이게
            buttonPosition.x += 480;                 // 다음 버튼 위치 조정
        }
    }

}
