using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Item_RapidShoot : ItemBase
{
    private void Awake()
    {
        this.num = 0;
        this.level = 0;
        this.maxlevel = 5;
        this.synergeNum = 0;
    }

    public override void itemEffect()
    {
        StartCoroutine(RapidShoot(level * 0.5f));
    }

    IEnumerator RapidShoot(float duration)
    {
        while(duration > 0)
        {
            Instantiate(ItemObj);
            yield return new WaitForSeconds(0.2f);
            duration -= Time.deltaTime;
        }
        yield return null;
    }
}
