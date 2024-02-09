using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Item_AttachBomb : ItemBase
{
    Transform shootPos;

    private void Awake()
    {
        this.itemname = "AttachBomb";
        this.num = 3;
        this.delay = 5.0f;
        this.level = 0;
        this.maxlevel = 5;
        this.synergeNum = 3;

        this.isActive = true;

    }
    public override void getItem()
    {
        base.getItem();
        this.delay -= (level - 1) * 1f;
    }

    public override void itemEffect()
    {
        if(!once)
        {
            this.shootPos = GetComponentInParent<PlayerSkill>().ShootPos;
            once = true;
        }

        StartCoroutine(AttachBomb(this.level));
    }

    IEnumerator AttachBomb(int count)
    {
        Instantiate(ItemObj, this.shootPos.position, Quaternion.identity);

        yield return null;
    }
}
