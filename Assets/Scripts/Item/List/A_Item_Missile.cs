using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Item_Missile : ItemBase
{
    Transform shootPos;

    private void Awake()
    {
        this.itemname = "Missile";
        this.num = 1;
        this.delay = 3.0f;
        this.level = 0;
        this.maxlevel = 5;
        this.synergeNum = 1;

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
            this.shootPos = GetComponentInParent<PlayerSkill>().ShootPos;
            once = true;
        }

        StartCoroutine(Missile(this.level));
    }

    IEnumerator Missile(int count)
    {
        while(count != 0)
        {
            Instantiate(ItemObj,this.shootPos.position,Quaternion.identity);
            count--;
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
    }
}
