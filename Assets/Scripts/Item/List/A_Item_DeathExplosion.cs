using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Item_DeathExplosion : ItemBase
{
    bool isActivate = false;

    [SerializeField]
    GameObject basic;

    private void Awake()
    {
        this.itemname = "DeathExplosion";
        this.num = 4;
        this.delay = 0f;
        this.level = 0;
        this.maxlevel = 5;
        this.synergeNum = 4;

        this.isActive = true;

        this.basic = GetComponentInParent<PlayerSkill>().basicBullet;
    }

    public override void itemEffect()
    {
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
