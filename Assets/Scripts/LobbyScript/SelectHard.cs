using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectHard : MonoBehaviour
{
    public static SelectHard instance; //½Ì±ÛÅæÀ» À§ÇÑ º¯¼ö
    public Outline normal_outline;
    public Outline easy_outline;
    public Outline hard_outline;
    public GameObject hard_text;
    public GameObject normal_text;
    public GameObject easy_text;
    public bool active_hard = false;

    //½Ì±ÛÅæÀ» À§ÇÑ ÇÔ¼ö
    private void Awake()
    {
        if(SelectHard.instance==null)
        {
            SelectHard.instance = this;
        }
    }
    public void OnClick()
    {
        normal_outline.enabled = false;
        easy_outline.enabled = false;
        hard_outline.enabled = true;
        hard_text.SetActive(true);
        normal_text.SetActive(false);
        easy_text.SetActive(false);
        active_hard = true;
        SelectNormal.instance.active_normal = false;
        SelectEasy.instance.active_easy = false;
    }
}
