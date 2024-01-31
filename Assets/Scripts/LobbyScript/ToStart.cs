using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStart : MonoBehaviour
{
    //¾À ÀüÈ¯
    public void OnClick()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1.0f;
        PauseMenu.gamePaused = false;
    }
}
