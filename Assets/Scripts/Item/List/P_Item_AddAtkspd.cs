using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Item_AddAtkspd : ItemBase
{
    private void Awake()
    {
        this.num = 0;
        this.level = 0;
        this.maxlevel = 9;
        this.synergeNum = 0;
    }

    public override void itemEffect()
    {
        PlayerStat.instance.AttSpd -= 0.05f;
    }
}
