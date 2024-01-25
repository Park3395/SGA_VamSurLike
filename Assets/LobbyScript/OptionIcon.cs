using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionIcon : MonoBehaviour
{
    public GameObject option;
    public void OnClick()
    {
        option.gameObject.SetActive(true);
    }
}
