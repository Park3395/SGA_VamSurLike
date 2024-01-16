using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCommando : MonoBehaviour
{
    public GameObject lobby_commando;
    public GameObject commando_information;
    public GameObject readyicon;
    

    public void OnClick()
    {
        commando_information.gameObject.SetActive(true);
        readyicon.gameObject.SetActive(true);
        lobby_commando.gameObject.SetActive(true);
        
    }
    
}
