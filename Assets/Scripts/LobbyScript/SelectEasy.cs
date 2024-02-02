using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectEasy : MonoBehaviour
{
    public static SelectEasy instance; //½Ì±ÛÅæÀ» À§ÇÑ º¯¼ö
    public Outline normal_outline;
    public Outline easy_outline;
    public Outline hard_outline;
    public GameObject easy_text;
    public GameObject normal_text;
    public GameObject hard_text;
    public bool active_easy = false;

    //½Ì±ÛÅæÀ» À§ÇÑ ÇÔ¼ö
    private void Awake()
    {
        if(SelectEasy.instance == null)
        {
            SelectEasy.instance = this;
        }
    }
    public void OnClick()
    {
        normal_outline.enabled = false;
        easy_outline.enabled = true;
        hard_outline.enabled = false;
        easy_text.SetActive(true);
        normal_text.SetActive(false);
        hard_text.SetActive(false);
        active_easy = true;
        SelectNormal.instance.active_normal = false;
        SelectHard.instance.active_hard = false;
    }
}
