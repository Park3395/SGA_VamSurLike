using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QCoolDownUI : MonoBehaviour
{
    [SerializeField]
    private Image cooldown;
    [SerializeField]
    private Text CooldownTxt;

    [SerializeField]
    private PlayerSkill Pskill;

    private void Update()
    {
        cooldown.fillAmount = Pskill.nowQSTime / (Pskill.QButtonDelay * PlayerStat.instance.AttSpd);

        if (Pskill.nowQSTime > 0)
            CooldownTxt.text = Mathf.Round(Pskill.nowQSTime).ToString();
        else
            CooldownTxt.text = "";
    }
}
