using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBandit : MonoBehaviour
{
    //�κ� �����ϴ� ������Ʈ�� ����
    public GameObject lobby_bandit;
    public GameObject bandit_information;
    public GameObject lobby_huntress;
    public GameObject huntress_information;
    public GameObject readyicon;
    public GameObject lobby_commando;
    public GameObject commando_information;
    public GameObject lobby_gunner;
    public GameObject gunner_information;

    //Ŭ���� �� ������ ������ ���� ������ �ٸ� ������ �𵨵��� ���ش�
    public void OnClick()
    {
        lobby_bandit.SetActive(true);
        bandit_information.SetActive(true);
        readyicon.gameObject.SetActive(true);
        huntress_information.gameObject.SetActive(false);
        lobby_huntress.gameObject.SetActive(false);
        lobby_commando.gameObject.SetActive(false);
        commando_information.gameObject.SetActive(false);
        lobby_gunner.SetActive(false);
        gunner_information.SetActive(false);

    }
}
