using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectIcon : MonoBehaviour
{
    [SerializeField] GameObject Active1;
    [SerializeField] GameObject Active2;
    [SerializeField] GameObject Active3;
    [SerializeField] GameObject Active4;
    [SerializeField] GameObject Active5;
    [SerializeField] GameObject inActive1;
    [SerializeField] GameObject inActive2;
    [SerializeField] GameObject inActive3;
    [SerializeField] GameObject inActive4;
    [SerializeField] GameObject inActive5;
    [SerializeField] Outline Active_outline1;
    [SerializeField] Outline inActive_outline1;
    [SerializeField] Outline inActive_outline2;
    [SerializeField] Outline inActive_outline3;
    [SerializeField] Outline inActive_outline4;
    [SerializeField] Outline inActive_outline5;
    

    public void OnClick()
    {
        Active1.SetActive(true);
        Active2.SetActive(true);
        Active3.SetActive(true);
        Active4.SetActive(true);
        Active5.SetActive(true);
        inActive1.SetActive(false);
        inActive2.SetActive(false);
        inActive3.SetActive(false);
        inActive4.SetActive(false);
        inActive5.SetActive(false);
        Active_outline1.enabled = true;
        inActive_outline1.enabled = false;
        inActive_outline2.enabled = false;
        inActive_outline3.enabled = false;
        inActive_outline4.enabled = false;
        inActive_outline5.enabled = false;
    }
}
