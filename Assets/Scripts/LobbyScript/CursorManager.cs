using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
   public GameObject pauseoption = GameObject.Find("pauseoption"); //pauseoption�� ã�´�
    void Update()
    {
       
       if(pauseoption.activeSelf ==true) //pauseoption�� Ȱ��ȭ ������ ��
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

       if(pauseoption.activeSelf ==false) //pauseoption�� ��Ȱ��ȭ ������ ��
        {
            Cursor.visible=false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
