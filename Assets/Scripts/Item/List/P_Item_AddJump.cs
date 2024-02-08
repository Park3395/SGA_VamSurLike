using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Item_AddJump : ItemBase
{
    private void Awake()
    {
        this.itemname = "AddJump";
        this.num = 2;
        this.level = 0;
        this.maxlevel = 4;
        this.synergeNum = 2;
        this.isActive = false;
    }

    public override void getItem()
    {
        base.getItem();
        PlayerStat.instance.JumpCount++;
    }
}
