using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayResolution : MonoBehaviour
{
    public int width;
    public int height;
    
    public void SetNowResolution()
    {
        Screen.SetResolution(width, height, true);
        Debug.Log("해상도 조절");

    }
}
