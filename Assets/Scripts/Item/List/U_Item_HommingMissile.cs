using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_Item_HommingMissile : ItemBase
{
    Transform shootPos;

    private void Awake()
    {
        this.itemname = "HommingMissile";
        this.num = 1;
        this.delay = 3.0f;
        this.level = 0;
        this.maxlevel = 1;
        this.synergeNum = 1;

        this.isActive = true;

        this.shootPos = GetComponentInParent<PlayerSkill>().Body;
    }

    public override void itemEffect()
    {
        StartCoroutine(Homming());
    }

    IEnumerator Homming()
    {
        WaitForSeconds t = new WaitForSeconds(0.3f);

        Instantiate(ItemObj,shootPos.position,Quaternion.identity);
        yield return t;
        Instantiate(ItemObj, shootPos.position, Quaternion.identity);
        yield return t;
        Instantiate(ItemObj, shootPos.position, Quaternion.identity);
        yield return t;
        Instantiate(ItemObj, shootPos.position, Quaternion.identity);
        yield return t;
        Instantiate(ItemObj, shootPos.position, Quaternion.identity);
        yield return t;
        Instantiate(ItemObj, shootPos.position, Quaternion.identity);
        yield return t;

        yield return null;
    }
}
