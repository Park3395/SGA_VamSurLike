using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InformationButton : MonoBehaviour
{
    public GameObject information;
    public GameObject ex_information;
    

    public void OnClick()
    {
        information.gameObject.SetActive(true);
        ex_information.gameObject.SetActive(false);
    }
}
