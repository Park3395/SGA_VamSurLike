using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownActivator : MonoBehaviour
{
    public PlayerSkill pSkill;

    public GameObject RCSkillUI;
    public GameObject QSkillUI;

    private void Update()
    {
        if(pSkill.onKeyItems[0] != null)
            RCSkillUI.SetActive(true);
        if(pSkill.onKeyItems[1] != null)
            QSkillUI.SetActive(true);
    }
}
