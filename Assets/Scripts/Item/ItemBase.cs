using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public int num;
    
    public int level;
    public int maxlevel;
    
    public int synergeNum;

    [SerializeField]
    protected GameObject ItemObj;

    virtual public void itemEffect() 
    {
        if(ItemObj != null)
            Instantiate(ItemObj);
    }
}
