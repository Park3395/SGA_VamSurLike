using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCommando : MonoBehaviour
{
    //�κ� �����ϴ� ������Ʈ�� ����
    public GameObject lobby_commando;
    public GameObject commando_information;
    public GameObject readyicon;
    public GameObject lobby_huntress;
    public GameObject huntress_information;
    public GameObject lobby_bandit;
    public GameObject bandit_information;
    public GameObject lobby_gunner;
    public GameObject gunner_information;

    //Ŭ���� �� �ڸ����� ������ ���� ������ �ٸ� ������ �𵨵��� ���ش�
    public void OnClick()
    {
        commando_information.gameObject.SetActive(true);
        readyicon.gameObject.SetActive(true);
        lobby_commando.gameObject.SetActive(true);
        lobby_huntress.gameObject.SetActive(false);
        huntress_information.gameObject.SetActive(false);
        lobby_bandit.SetActive(false);
        bandit_information.SetActive(false);
        lobby_gunner.SetActive(false);
        gunner_information.SetActive(false);

    }
    
}
