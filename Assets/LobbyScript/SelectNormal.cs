using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectNormal : MonoBehaviour
{
    public Outline normal_outline;
    public Outline easy_outline;
    public Outline hard_outline;

    public void OnClick()
    {
        normal_outline.enabled = true;
        easy_outline.enabled = false;
        hard_outline.enabled = false;
    }
    
}
