using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_Item_MachineGun : ItemBase
{
    private void Awake()
    {
        this.itemname = "U_MachineGun";
        this.num = 0;
        this.delay = 0;
        this.level = 0;
        this.maxlevel = 1;
        this.synergeNum = 0;

        this.isActive = true;
    }

    public override void itemEffect()
    {
        StartCoroutine(RapidShoot(level * 0.5f));
    }

    IEnumerator RapidShoot(float duration)
    {
        while (duration > 0)
        {
            Instantiate(ItemObj);
            yield return new WaitForSeconds(0.2f);
            duration -= Time.deltaTime;
        }
        yield return null;
    }
}
