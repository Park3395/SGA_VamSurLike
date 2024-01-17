using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCommando : MonoBehaviour
{
    public GameObject lobby_commando;
    public GameObject commando_information;
    public GameObject readyicon;
    public GameObject lobby_huntress;
    public GameObject huntress_information;
    public GameObject lobby_bandit;
    public GameObject bandit_information;


    public void OnClick()
    {
        commando_information.gameObject.SetActive(true);
        readyicon.gameObject.SetActive(true);
        lobby_commando.gameObject.SetActive(true);
        lobby_huntress.gameObject.SetActive(false);
        huntress_information.gameObject.SetActive(false);
        lobby_bandit.SetActive(false);
        bandit_information.SetActive(false);

    }
    
}
