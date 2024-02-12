using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RCoolDownUI : MonoBehaviour
{
    [SerializeField]
    private Image cooldown;
    [SerializeField]
    private Text CooldownTxt;

    [SerializeField]
    private PlayerSkill Pskill;

    private void Update()
    {
        cooldown.fillAmount = Pskill.nowRSTime / (Pskill.RButtonDelay * PlayerStat.instance.AttSpd);

        if (Pskill.nowRSTime > 0)
            CooldownTxt.text = Mathf.Round(Pskill.nowRSTime).ToString();
        else
            CooldownTxt.text = "";
    }
}
