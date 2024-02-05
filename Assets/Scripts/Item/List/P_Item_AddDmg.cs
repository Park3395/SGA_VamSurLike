using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Item_AddDmg : ItemBase
{
    private void Awake()
    {
        this.num = 1;
        this.level = 0;
        this.maxlevel = 9;
        this.synergeNum = 1;
    }

    public override void itemEffect()
    {
        PlayerStat.instance.Dmg *= 1.5f;
    }
}
