using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionCloser : MonoBehaviour
{
    public GameObject Option;

    public void OnClick()
    {
        Option.SetActive(false);
    }
}
