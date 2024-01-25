using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeIcon : MonoBehaviour
{
    public GameObject slider;
    public void OnClick()
    {
        slider.gameObject.SetActive(true);
    }
}
