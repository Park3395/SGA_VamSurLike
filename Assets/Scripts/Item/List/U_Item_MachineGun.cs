using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_Item_MachineGun : ItemBase
{
    Transform shootPos;
    bool isOn = false;
    float t;

    private void Awake()
    {
        this.itemname = "MachineGun";
        this.num = 10;
        this.index = 10;
        this.delay = 0;
        this.level = 0;
        this.maxlevel = 1;
        this.synergeNum = 5;

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

        isOn = !isOn;
    }
    private void Update()
    {
        if(isOn)
        {
            if (t < 0f)
            {
                Instantiate(ItemObj,this.shootPos.position,Quaternion.identity);
                t = 0.2f;
            }
            else
                t -= Time.deltaTime;
        }
        else
        {
            t = 0.2f;
        }
    }
}
