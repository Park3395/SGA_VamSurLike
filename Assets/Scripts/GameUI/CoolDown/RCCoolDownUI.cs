using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RCCoolDownUI : MonoBehaviour
{
    [SerializeField]
    private Image cooldown;
    [SerializeField]
    private Text CooldownTxt;

    [SerializeField]
    private PlayerSkill Pskill;

    private void Update()
    {
        cooldown.fillAmount = Pskill.nowRCSTime / (Pskill.RightSkillDelay * PlayerStat.instance.AttSpd);

        if (Pskill.nowRCSTime > 0)
            CooldownTxt.text = Mathf.Round(Pskill.nowRCSTime).ToString();
        else
            CooldownTxt.text = "";
    }
}
