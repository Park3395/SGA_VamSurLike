using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
