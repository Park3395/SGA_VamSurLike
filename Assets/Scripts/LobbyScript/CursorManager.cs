using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
   public GameObject pauseoption = GameObject.Find("pauseoption"); //pauseoption을 찾는다
    void Update()
    {
       
       if(pauseoption.activeSelf ==true) //pauseoption이 활성화 상태일 때
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

       if(pauseoption.activeSelf ==false) //pauseoption이 비활성화 상태일 때
        {
            Cursor.visible=false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
