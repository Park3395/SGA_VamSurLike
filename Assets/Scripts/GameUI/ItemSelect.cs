using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour
{
    public Button[] allButtons;     //인스펙터에서 버튼프리팹 넣는곳
    private Button[] buttonObjects; //버튼 Instantiate 할때 쓰는 배열 
    public GameObject ItemSelectCanvas; // destroy할 캔버스
    private PlayerStat playerStat;

    //List<string> itemIndices = new List<string>(); //아이템 뭐얻었는지 저장하는 리스트
    // 게임매니저 스크립트 가져오기
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
                buttonIndex = UnityEngine.Random.Range(0, 10);
            } while (uniqueIndices.Contains(buttonIndex));

            // 찾은 인덱스를 리스트에 추가
            uniqueIndices.Add(buttonIndex);

            // 버튼 프리팹 Instantiate
            buttonObjects[i] = Instantiate(allButtons[buttonIndex],
                buttonPosition, Quaternion.identity);
            // 캔버스의 자식으로 설정해서 화면에 보이게
            buttonObjects[i].transform.SetParent(transform);    
            buttonPosition.x += 480;    // 다음 버튼 위치 조정
        }
    }

    public void ButtonAttackPower()
    {
        // 게임매니저에 있는 리스트에 아이템 뭐선택했는지 저장
        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add("Dmg");
        // 플레이어 스탯 스크립트의 변수 변경
        playerStat = PlayerStat.instance;
        playerStat.Dmg += 5;
        // 아이템 선택 캔버스 없애기
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        // 시간흐름 다시 되돌리기
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
