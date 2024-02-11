using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public GameObject pauseoption;
    GameObject ItemSelectCanvas;
    GameObject LoseCanvas;
    GameObject WinCanvas;

    private void Start()
    {
        //pauseoption = GameObject.Find("PauseMenu_Canvas 1"); //pauseoption을 찾는다
        // 비활성화된 오브젝트는 찾기안되서 인스펙터로 등록
    }
    void Update()
    {
        ItemSelectCanvas = GameObject.Find("Demo_Canvas_ItemSelect(Clone)");
        LoseCanvas = GameObject.Find("Canvas_Lose 1(Clone)");
        WinCanvas = GameObject.Find("Canvas_Win(Clone)");

        if (pauseoption.activeSelf == true) //pauseoption이 활성화 상태일 때
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
        if (pauseoption.activeSelf == false)    //pauseoption이 비활성화 상태일 때
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            // 커서가 있어야할 켄버스 있으면 비활성화 x
            if (ItemSelectCanvas||LoseCanvas||WinCanvas)   
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
