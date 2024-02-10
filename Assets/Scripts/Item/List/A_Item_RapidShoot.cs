using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Item_RapidShoot : ItemBase
{
    Transform shootPos;

    private void Awake()
    {
        this.itemname = "RapidShoot";
        this.num = 0;
        this.index = 0;
        this.delay = 2.0f;
        this.level = 0;
        this.maxlevel = 5;
        this.synergeNum = 0;
        this.isActive = true;

    }
    public override void getItem()
    {
        base.getItem();
    }

    public override void itemEffect()
    {
        if (!once)
        {
            this.ItemObj = GetComponentInParent<PlayerSkill>().basicBullet;
            this.shootPos = GetComponentInParent<PlayerSkill>().ShootPos;
            once = true;
        }

        StartCoroutine(RapidShoot(level * 0.05f));
    }

    IEnumerator RapidShoot(float duration)
    {
        while(duration > 0)
        {
            Instantiate(ItemObj, shootPos.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            duration -= Time.deltaTime;
            Debug.Log(duration);
        }
        yield return null;
    }
}
