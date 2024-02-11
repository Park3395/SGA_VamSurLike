using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_Item_GreatBomb : ItemBase
{
    Transform shootPos;
    private void Awake()
    {
        this.itemname = "GreatBomb";
        this.num = 3;
        this.index = 13;
        this.delay = 5.0f;
        this.level = 0;
        this.maxlevel = 1;
        this.synergeNum = 3;

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

        StartCoroutine(GreateBomb());
    }

    IEnumerator GreateBomb()
    {
        Vector3 pos = shootPos.position;
        yield return new WaitForSeconds(2.0f);
        Instantiate(ItemObj,pos,Quaternion.identity);
    }
}
