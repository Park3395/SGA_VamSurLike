using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_Item_RoundImpact : ItemBase
{
    Transform shootPos;

    private void Awake()
    {
        this.itemname = "RoundImpact";
        this.num = 12;
        this.index = 12;
        this.delay = 3.0f;
        this.level = 0;
        this.maxlevel = 1;
        this.synergeNum = 7;

        this.isActive = true;

    }
    public override void getItem()
    {
        base.getItem();
    }

    public override void itemEffect()
    {
        if(!once)
        {
            this.shootPos = GetComponentInParent<PlayerSkill>().Body;
            once = true;
        }

        Instantiate(ItemObj,shootPos.position,Quaternion.identity);
    }
}
