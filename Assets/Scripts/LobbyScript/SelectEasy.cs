using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectEasy : MonoBehaviour
{
    public Outline normal_outline;
    public Outline easy_outline;
    public Outline hard_outline;

    public void OnClick()
    {
        normal_outline.enabled = false;
        easy_outline.enabled = true;
        hard_outline.enabled = false;
    }
}
