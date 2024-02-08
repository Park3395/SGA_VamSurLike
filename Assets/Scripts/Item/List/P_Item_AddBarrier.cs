using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Item_AddBarrier : ItemBase
{
    private void Awake()
    {
        this.itemname = "AddBarrier";
        this.num = 3;
        this.level = 0;
        this.maxlevel = 5;
        this.synergeNum = 3;
        this.isActive = false;
    }

    public override void getItem()
    {
        base.getItem();
        if (this.level == 1)
            PlayerStat.instance.Barrier += 200;
        else
            PlayerStat.instance.Barrier += 100;

    }
}
