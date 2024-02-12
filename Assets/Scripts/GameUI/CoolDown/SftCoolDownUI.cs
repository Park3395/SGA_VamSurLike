using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SftCoolDownUI : MonoBehaviour
{
    [SerializeField]
    private Image cooldown;
    [SerializeField]
    private Text CooldownTxt;

    [SerializeField]
    private PlayerSkill Pskill;

    private void Update()
    {
        cooldown.fillAmount = Pskill.nowSSTime / (Pskill.ShiftSkillDelay * PlayerStat.instance.AttSpd);

        if (Pskill.nowSSTime > 0)
            CooldownTxt.text = Mathf.Round(Pskill.nowSSTime).ToString();
        else
            CooldownTxt.text = "";
    }
}
