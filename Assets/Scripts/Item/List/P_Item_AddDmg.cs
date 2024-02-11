using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Item_AddDmg : ItemBase
{
    private void Awake()
    {
        this.itemname = "AddDmg";
        this.num = 1;
        this.index = 6;
        this.level = 0;
        this.maxlevel = 5;
        this.synergeNum = 1;
        this.isActive = false;
    }

    public override void getItem()
    {
        base.getItem();
        PlayerStat.instance.Dmg *= 1.5f;
    }
}
