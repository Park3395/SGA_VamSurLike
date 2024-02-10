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
        //pauseoption = GameObject.Find("PauseMenu_Canvas 1"); //pauseoption�� ã�´�
        // ��Ȱ��ȭ�� ������Ʈ�� ã��ȵǼ� �ν����ͷ� ���
    }
    void Update()
    {
        ItemSelectCanvas = GameObject.Find("Demo_Canvas_ItemSelect(Clone)");
        LoseCanvas = GameObject.Find("Canvas_Lose 1(Clone)");
        WinCanvas = GameObject.Find("Canvas_Win(Clone)");

        if (pauseoption.activeSelf == true) //pauseoption�� Ȱ��ȭ ������ ��
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
        if (pauseoption.activeSelf == false)    //pauseoption�� ��Ȱ��ȭ ������ ��
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            // Ŀ���� �־���� �˹��� ������ ��Ȱ��ȭ x
            if (ItemSelectCanvas||LoseCanvas||WinCanvas)   
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
