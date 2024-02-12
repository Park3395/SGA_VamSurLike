using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_Item_Ignite : ItemBase
{
    bool isActivate = false;

    [SerializeField]
    GameObject basic;

    private void Awake()
    {
        this.itemname = "Ignite";
        this.num = 4;
        this.index = 14;
        this.delay = 0;
        this.level = 0;
        this.maxlevel = 1;
        this.synergeNum = 4;

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
            this.basic = GetComponentInParent<PlayerSkill>().basicBullet;
            once = true;
        }

        if (this.isActivate)
        {
            this.isActivate = false;
            GetComponentInParent<PlayerSkill>().basicBullet = this.basic;
        }
        else
        {
            this.isActivate = true;
            GetComponentInParent<PlayerSkill>().basicBullet = this.ItemObj;
        }
    }
}