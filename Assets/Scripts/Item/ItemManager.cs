using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    [SerializeField]
    ItemBase[] ActiveItems;
    [SerializeField]
    ItemBase[] PassiveItems;
    [SerializeField]
    ItemBase[] UpgradeItems;

    [SerializeField]
    GameObject LevelCanvas;

    [SerializeField]
    public List<ItemBase> PlayerActive;
    [SerializeField]
    public List<ItemBase> PlayerPassive;

    PlayerStat pStat;

    [SerializeField]
    Canvas ItemSelect;

    private void Start()
    {
        pStat = PlayerStat.instance;
        PlayerActive = new List<ItemBase>();
        PlayerPassive = new List<ItemBase>();
    }

    private void Update()
    {
        int levelexp = (pStat.Plevel + 1) * 100;

        if (pStat.Pexp >= levelexp)
        {
            Debug.Log("Level Up");
            pStat.Pexp -= levelexp;
            pStat.Plevel++;
            Instantiate(ItemSelect, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    public ItemBase selectItem(int num, bool isActive, bool isSelect)
    {
        if (isActive)
        {
            ItemBase item = new ItemBase();
            item = PlayerActive.Find(x => x.num != num);
            
            if (item == null)
            {
                if(isSelect)
                {
                    PlayerActive.Add(ActiveItems[num]);
                    return PlayerActive.Find(x => x.num == num);
                }
                else
                    return ActiveItems[num];
            }
            else
            {
                if (item.level == item.maxlevel)
                    if (PlayerPassive.Find(x => x.synergeNum == num))
                    {
                        PlayerActive.Remove(item);
                        PlayerActive.Add(UpgradeItems[num]);
                    }
                return PlayerActive.Find(x => x.num == num);
            }
        }
        else
        {
            ItemBase item = new ItemBase();
            item = PlayerPassive.Find(x => x.num != num);
            
            if (item == null)
            {
                if(isSelect)
                {
                    PlayerPassive.Add(PassiveItems[num]);
                    return PlayerPassive.Find(x => x.num == num);
                }
                else
                    return PassiveItems[num];
            }
            else
                return PlayerPassive.Find(x => x.num == num);
        }
    }
}
