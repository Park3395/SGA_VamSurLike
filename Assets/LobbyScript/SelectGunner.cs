using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectGunner : MonoBehaviour
{
    //�κ� �����ϴ� ������Ʈ�� ����
    public GameObject lobby_gunner;
    public GameObject gunner_information;
    public GameObject lobby_huntress;
    public GameObject huntress_information;
    public GameObject readyicon;
    public GameObject lobby_commando;
    public GameObject commando_information;
    public GameObject lobby_bandit;
    public GameObject bandit_information;
    public Outline commando_outline;
    public Outline huntress_outline;
    public Outline bandit_outline;
    public Outline gunner_outline;

    //Ŭ���� �� ���ϰų��� ������ ���� ������ �ٸ� ������ �𵨵��� ���ش�
    public void OnClick()
    {
        lobby_gunner.SetActive(true);
        gunner_information.SetActive(true);
        huntress_information.gameObject.SetActive(false);
        readyicon.gameObject.SetActive(true);
        lobby_huntress.gameObject.SetActive(false);
        lobby_commando.gameObject.SetActive(false);
        commando_information.gameObject.SetActive(false);
        lobby_bandit.SetActive(false);
        bandit_information.SetActive(false);
        commando_outline.enabled = false;  //outline�� �� enabled �ϱ�???
        huntress_outline.enabled = false;
        bandit_outline.enabled = false;
        gunner_outline.enabled = true;


    }
}
