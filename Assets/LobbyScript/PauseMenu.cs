using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(!gamePaused && Input.GetKeyDown(KeyCode.Escape))
        {
            gamePaused = true;
            PauseMenuOn();
            
        }
        
        
        if (gamePaused && Input.GetKeyDown(KeyCode.Escape))
        {
            gamePaused = false;
            PauseMenuOff();
        }
        


    }

    void PauseMenuOn()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    void PauseMenuOff()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }


}
