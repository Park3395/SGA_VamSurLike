using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour
{
    public Button[] allButtons;     
    [SerializeField]
    private Button[] buttonObjects; 
    public GameObject ItemSelectCanvas; 

    //List<string> itemIndices = new List<string>(); 
    private GameManager gameManagerInstance;
    public GameObject InventoryCanvas; 

    public Image[] itemSpriteHolder;
    public Image[] itemSpriteHolder2;
    public Sprite[] ItemSprites;

    PlayerStat playerStat;

    /////////////////////////////////////////

    ItemManager IM;
    ItemBase[] itemArray;
    struct ItemData
    {
        public int num;
        public bool isActive;
    }

    /////////////////////////////////////////

    int loopNum;

    void Awake()
    {
        ItemButtonInstantiate();
    }

    void Update()
    {
    }

    void ItemButtonInstantiate()
    {
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None;   

        playerStat = PlayerStat.instance;
        IM = ItemManager.instance;

        buttonObjects = new Button[3];
        itemArray = new ItemBase[3];

        Vector3 buttonPosition = new Vector3();
        buttonPosition.x = 480;
        buttonPosition.y = 480;

        List<int> uniqueIndices = new List<int>();

        for (int i = 0; i < 3; i++)
        {
            int buttonIndex;

            loopNum = 0;
            do
            {
                buttonIndex = UnityEngine.Random.Range(0, 10);
                if (loopNum >= 100)
                { 
                    break;
                }
            } while (uniqueIndices.Contains(buttonIndex));

            uniqueIndices.Add(buttonIndex);

            /////////////////////////////////////////
            if (buttonIndex >= 5)
            {
                itemArray[i] = IM.checkInstantiate(buttonIndex % 5, true, this.gameObject);
            }
            else
            {
                itemArray[i] = IM.checkInstantiate(buttonIndex, false, this.gameObject);
            }

            /////////////////////////////////////////

            buttonObjects[i] = Instantiate(allButtons[buttonIndex],
                buttonPosition, Quaternion.identity);
            buttonObjects[i].transform.SetParent(transform);


            /////////////////////////////////////////
            buttonObjects[i].transform.Find("LvText").GetComponent<Text>().text
                = String.Format($"Lv {itemArray[i].level} / Lv {itemArray[i].maxlevel}");
            
            //buttonObjects[i].transform.GetChild(2).GetComponent<Text>().text
            //    = String.Format($"Lv {temp.level} / Lv {temp.maxlevel}");

            if (i == 0)
                buttonObjects[i].onClick.AddListener(onItemButton1);
            else if (i == 1)
                buttonObjects[i].onClick.AddListener(onItemButton2);
            else if (i == 2)
                buttonObjects[i].onClick.AddListener(onItemButton3);

            /////////////////////////////////////////////////////////////////


            /////////////////////////////////////////
            buttonPosition.x += 480;    
        }
    }

    /////////////////////////////////////////
    public void onItemButton1()
    {
        Debug.Log("Click1");
        IM.selectItem(itemArray[0]);

        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add(itemArray[0].index);

        ItemSelectCanvas = GameObject.Find("Demo_Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }

        Time.timeScale = 1;
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
        FindImageHolder();
        ShowItemUI();
    }

    public void onItemButton2()
    {
        Debug.Log("Click2");
        IM.selectItem(itemArray[1]);

        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add(itemArray[1].index);

        ItemSelectCanvas = GameObject.Find("Demo_Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }

        Time.timeScale = 1;
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
        FindImageHolder();
        ShowItemUI();
    }

    public void onItemButton3()
    {
        Debug.Log("Click3");
        IM.selectItem(itemArray[2]);

        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add(itemArray[2].index);

        ItemSelectCanvas = GameObject.Find("Demo_Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }

        Time.timeScale = 1;
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
        FindImageHolder();
        ShowItemUI();
    }
    

    public void ShowItemUI()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();

        for (int i = 0; i < gameManagerInstance.itemIndices.Count; i++)
        {
            switch (gameManagerInstance.itemIndices[i])
            {
                case 0:
                    itemSpriteHolder2[i].sprite = ItemSprites[0];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case 1:                    
                    itemSpriteHolder2[i].sprite = ItemSprites[1];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case 2:
                    itemSpriteHolder2[i].sprite = ItemSprites[2];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case 3:
                    itemSpriteHolder2[i].sprite = ItemSprites[3];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case 4:
                    itemSpriteHolder2[i].sprite = ItemSprites[4];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case 5:
                    itemSpriteHolder2[i].sprite = ItemSprites[5];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case 6:
                    itemSpriteHolder2[i].sprite = ItemSprites[6];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case 7:
                    itemSpriteHolder2[i].sprite = ItemSprites[7];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case 8:
                    itemSpriteHolder2[i].sprite = ItemSprites[8];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case 9:
                    itemSpriteHolder2[i].sprite = ItemSprites[9];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case 10:
                    itemSpriteHolder2[i].sprite = ItemSprites[10];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case 11:
                    itemSpriteHolder2[i].sprite = ItemSprites[11];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case 12:
                    itemSpriteHolder2[i].sprite = ItemSprites[12];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case 13:
                    itemSpriteHolder2[i].sprite = ItemSprites[13];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case 14:
                    itemSpriteHolder2[i].sprite = ItemSprites[14];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                default:
                    Debug.Log("case에서 못찾음");
                    break;

            }
        }
    }

    void FindImageHolder()
    {
        InventoryCanvas = GameObject.Find("Canvas_wave,time,item");
        Transform panelTransform = InventoryCanvas.transform.Find("Panel_Item");
        if (panelTransform != null)
        {            
            int childCount = panelTransform.childCount;
            itemSpriteHolder2 = new Image[childCount];
            for (int i = 0; i < childCount; i++)
            {
                itemSpriteHolder2[i] = panelTransform.GetChild(i).GetComponent<Image>();
            }
        }
        else
        {
            Debug.Log("패널못찾음");
        }
    }
}
