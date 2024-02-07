using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Item_AddDmg : ItemBase
{
    private void Awake()
    {
        this.itemname = "P_AddDmg";
        this.num = 1;
        this.level = 0;
        this.maxlevel = 9;
        this.synergeNum = 1;
        this.isActive = false;
    }

    public override void getItem()
    {
        PlayerStat.instance.Dmg *= 1.5f;
    }
}
