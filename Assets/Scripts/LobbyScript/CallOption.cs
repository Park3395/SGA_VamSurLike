using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallOption : MonoBehaviour
{
    public GameObject option;
    public static bool OnOption = false;
    

    public void OnClick()
    {
        option.SetActive(true);
        OnOption = true;
       
    }


}
