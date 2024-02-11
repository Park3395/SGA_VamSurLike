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

    public ItemBase checkInstantiate(int num, bool isActive, GameObject Target)
    {
        ItemBase temp;
        if(isActive)
        {
            temp = PlayerActive.Find(x => x.num == num);

            if (temp == null)
                return Instantiate(ActiveItems[num], Target.transform);
            else
                return temp;
        }
        else
        {
            temp = PlayerPassive.Find(x => x.num == num);

            if (temp == null)
                return Instantiate(PassiveItems[num], Target.transform);
            else
                return temp;
        }
    }

    public void selectItem(ItemBase Item)
    {
        if(Item.isActive)
        {
            ItemBase pItem = PlayerActive.Find(x => x.num == Item.num);
            if (pItem == null)
            {
                pItem = Instantiate(Item,this.transform);
                PlayerActive.Add(pItem);
                pItem.getItem();
            }
            else
            {
                pItem.getItem();

                if(pItem.level == pItem.maxlevel)
                {
                    PlayerActive.Remove(pItem);
                    PlayerActive.Add(UpgradeItems[Item.num]);
                    UpgradeItems[Item.num].getItem();
                }
            }
        }
        else
        {
            ItemBase pItem = PlayerPassive.Find(x => x.num == Item.num);
            if(pItem == null)
            {
                pItem = Instantiate(Item,this.transform);
                PlayerPassive.Add(pItem);
                pItem.getItem();
            }
            else
                pItem.getItem();
        }
    }
}
