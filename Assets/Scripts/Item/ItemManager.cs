using System.Collections;
using System.Collections.Generic;
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

    public ItemBase selectItem(int num, bool isActive)
    {
        if (isActive)
        {
            ItemBase item = PlayerActive.Find(x => x.num != num);

            if (item == null)
            {
                PlayerActive.Add(ActiveItems[num]);
            }
            else
            {
                item.level++;
            }

            if(item.level == item.maxlevel)
                if(PlayerPassive.Find(x=>x.synergeNum == num))
                {
                    PlayerActive.Remove(item);
                    PlayerActive.Add(UpgradeItems[num]);
                }

            return PlayerActive.Find(x => x.num == num);
        }
        else
        {
            ItemBase item = PlayerPassive.Find(x => x.num != num);
            if (item == null)
            {
                PlayerPassive.Add(PassiveItems[num]);
            }
            else
            {
                item.level++;
            }

            return PlayerPassive.Find(x=>x.num == num);
        }
    }
}
