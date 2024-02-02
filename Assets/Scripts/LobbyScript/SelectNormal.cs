using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectNormal : MonoBehaviour
{
    public static SelectNormal instance; //½Ì±ÛÅæÀ» À§ÇÑ º¯¼ö
    public Outline normal_outline;
    public Outline easy_outline;
    public Outline hard_outline;
    public GameObject normal_text;
    public GameObject easy_text;
    public GameObject hard_text;
    public bool active_normal = false;

    //½Ì±ÛÅæÀ» À§ÇÑ ÇÔ¼ö
    private void Awake()
    {
        if(SelectNormal.instance ==null)
        {
            SelectNormal.instance = this;
        }
    }

    public void OnClick()
    {
        normal_outline.enabled = true;
        easy_outline.enabled = false;
        hard_outline.enabled = false;
        normal_text.SetActive(true);
        easy_text.SetActive(false);
        hard_text.SetActive(false);
        active_normal = true;
        SelectEasy.instance.active_easy = false;
        SelectHard.instance.active_hard = false;
    }
    
}
