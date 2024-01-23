using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBandit : MonoBehaviour
{
    //로비를 구성하는 오브젝트들 모음
    public GameObject lobby_bandit;
    public GameObject bandit_information;
    public GameObject lobby_huntress;
    public GameObject huntress_information;
    public GameObject readyicon;
    public GameObject lobby_commando;
    public GameObject commando_information;
    public GameObject lobby_gunner;
    public GameObject gunner_information;

    //클릭할 시 도적의 정보와 모델을 제외한 다른 정보와 모델들을 없앤다
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
