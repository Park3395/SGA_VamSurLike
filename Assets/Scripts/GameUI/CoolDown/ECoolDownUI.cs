using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ECoolDownUI : MonoBehaviour
{
    [SerializeField]
    private Image cooldown;
    [SerializeField]
    private Text CooldownTxt;

    [SerializeField]
    private PlayerSkill Pskill;

    private void Update()
    {
        cooldown.fillAmount = Pskill.nowESTime / (Pskill.EButtonDelay * PlayerStat.instance.AttSpd);
        if (Pskill.nowESTime > 0)
            CooldownTxt.text = Mathf.Round(Pskill.nowESTime).ToString();
        else
            CooldownTxt.text = "";
    }
}
