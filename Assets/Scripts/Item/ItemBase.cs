using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public int num;
    public float delay;

    public int level;
    public int maxlevel;
    
    public int synergeNum;

    public bool isActive;

    [SerializeField]
    protected GameObject ItemObj;

    virtual public void itemEffect() 
    {
        
    }

    virtual public void getItem()
    {
        level++;

        if(isActive)
        {
            ItemBase[] keyItem = GetComponentInParent<PlayerSkill>().onKeyItems;
            for(int i = 0;i<4;i++)
            {
                if (keyItem[i] != null)
                {
                    keyItem[i] = this;
                    break;
                }
            }
        }
    }
}
