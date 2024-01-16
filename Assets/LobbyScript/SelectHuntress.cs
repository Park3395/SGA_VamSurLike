using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectHuntress : MonoBehaviour
{
    public GameObject lobby_huntress;
    public GameObject huntress_information;
    public GameObject readyicon;
    public GameObject lobby_commando;
    public GameObject commando_information;


    public void OnClick()
    {
        huntress_information.gameObject.SetActive(true);
        readyicon.gameObject.SetActive(true);
        lobby_huntress.gameObject.SetActive(true);
        lobby_commando.gameObject.SetActive(false);
        commando_information.gameObject.SetActive(false);

    }
}
