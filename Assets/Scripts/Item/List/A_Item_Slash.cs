using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Item_Slash : ItemBase
{
    Transform shootPos;

    private void Awake()
    {
        this.itemname = "Slash";
        this.num = 2;
        this.delay = 1.0f;
        this.level = 0;
        this.maxlevel = 3;
        this.synergeNum = 2;

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
            shootPos = GetComponentInParent<PlayerSkill>().Body;
            once = true;
        }

        StartCoroutine(Slash(this.level));
    }

    IEnumerator Slash(int size)
    {
        WaitForSeconds t = new WaitForSeconds(0.1f);
        if(size>0)
            Instantiate(ItemObj, this.shootPos.position, Quaternion.Euler(0,0,0));
        yield return t;
        if(size>1)
            Instantiate(ItemObj, this.shootPos.position, Quaternion.Euler(0, 60, 0));
        yield return t;
        if (size>2)
            Instantiate(ItemObj, this.shootPos.position, Quaternion.Euler(0, -60, 0));
        yield return t;

        yield return null;
    }
}
