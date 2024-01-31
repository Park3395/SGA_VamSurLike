using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenu;
    public GameObject halfDarkPanel;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!gamePaused) //gamePaused를 참으로 해놓고 있었으니 안 됐지....
            {
               
                PauseMenuOn();
            }
            
            else
            {
                
                PauseMenuOff();
            }
            
        }

       
          

    }

    void PauseMenuOn()
    {
        gamePaused = true;
        pauseMenu.gameObject.SetActive(true);
        halfDarkPanel.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    void PauseMenuOff()
    {
        gamePaused = false;
        pauseMenu.gameObject.SetActive(false);
        halfDarkPanel.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }


}
