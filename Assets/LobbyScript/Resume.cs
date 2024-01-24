using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject halfDarkPanel;
    public void PauseMenuOff()
    {
        PauseMenu.gamePaused = false;
        pauseMenu.gameObject.SetActive(false);
        halfDarkPanel.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
