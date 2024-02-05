using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    ItemBase[] ActiveItems;
    [SerializeField]
    ItemBase[] PassiveItems;
    [SerializeField]
    ItemBase[] UpgradeItems;

    [SerializeField]
    GameObject LevelCanvas;

    List<ItemBase> PlayerActive;
    List<ItemBase> PlayerPassive;

    PlayerStat pStat;

    private void Start()
    {
        pStat = PlayerStat.instance;
        PlayerActive = new List<ItemBase>();
        PlayerPassive = new List<ItemBase>();
    }

    private void Update()
    {
        int levelexp = pStat.Plevel * 100;

        if (pStat.Pexp >= levelexp)
        {
            Debug.Log("Level Up");
            pStat.Pexp -= levelexp;
            Time.timeScale = 0;
            LevelCanvas.SetActive(true);
        }
    }

    private void selectItem(int num, bool isActive)
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
        }
    }
}
