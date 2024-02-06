using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Item_Granade : ItemBase
{
    private void Awake()
    {
        this.num = 1;
        this.delay = 3.0f;
        this.level = 0;
        this.maxlevel = 5;
        this.synergeNum = 1;
        this.isActive = true;
    }

    public override void itemEffect()
    {
        StartCoroutine(SpawnGranade(this.level));
    }

    IEnumerator SpawnGranade(int count)
    {
        while(count != 0)
        {
            Instantiate(ItemObj);
            count--;
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
    }
}
