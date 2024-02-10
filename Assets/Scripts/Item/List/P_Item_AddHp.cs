using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Item_AddHp : ItemBase
{
    private void Awake()
    {
        this.itemname = "AddHp";
        this.num = 4;
        this.index = 9;
        this.level = 0;
        this.maxlevel = 6;
        this.synergeNum = 4;
        this.isActive = false;
    }

    public override void getItem()
    {
        base.getItem();
        PlayerStat.instance.MaxHP = (int)(PlayerStat.instance.MaxHP * 1.5f);
    }
}
