using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public string itemname;
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

        // 액티브 아이템이면 키 할당
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
