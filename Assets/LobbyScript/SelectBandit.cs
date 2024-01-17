using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBandit : MonoBehaviour
{
    public GameObject lobby_bandit;
    public GameObject bandit_information;
    public GameObject lobby_huntress;
    public GameObject huntress_information;
    public GameObject readyicon;
    public GameObject lobby_commando;
    public GameObject commando_information;


    public void OnClick()
    {
        lobby_bandit.SetActive(true);
        bandit_information.SetActive(true);
        readyicon.gameObject.SetActive(true);
        huntress_information.gameObject.SetActive(false);
        lobby_huntress.gameObject.SetActive(false);
        lobby_commando.gameObject.SetActive(false);
        commando_information.gameObject.SetActive(false);

    }
}
