using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour
{
    public Button[] allButtons;     //�ν����Ϳ��� ��ư������ �ִ°�
    [SerializeField]
    private Button[] buttonObjects; //��ư Instantiate �Ҷ� ���� �迭 
    public GameObject ItemSelectCanvas; // destroy�� ĵ����

    //List<string> itemIndices = new List<string>(); //������ ��������� �����ϴ� ����Ʈ
    // ���ӸŴ��� ��ũ��Ʈ ��������
    private GameManager gameManagerInstance;
    public GameObject InventoryCanvas; // Canvas �� ���� ����

    public Image[] itemSpriteHolder2;
    public Sprite[] ItemSprites2;

    public Image[] itemSpriteHolder;
    public Sprite[] ItemSprites;

    PlayerStat playerStat;

    ////////////////// �߰� ///////////////////////

    ItemManager IM;
    ItemBase[] itemArray;
    struct ItemData
    {
        public int num;
        public bool isActive;
    }

    ////////////////// �߰� ///////////////////////

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
        Cursor.visible = true; // Ŀ�� ���̰�
        Cursor.lockState = CursorLockMode.None;   // Ŀ�� �����̰�

        playerStat = PlayerStat.instance;
        IM = ItemManager.instance;

        // ��ư ������ ���� �迭 �ʱ�ȭ
        buttonObjects = new Button[3];
        itemArray = new ItemBase[3];

        // ��ư ��ġ
        Vector3 buttonPosition = new Vector3();
        // ù��° ��ư ��ġ
        buttonPosition.x = 480;
        buttonPosition.y = 480;

        // �ߺ����� ���� ������ ��ư �ε����� ������ ����Ʈ
        List<int> uniqueIndices = new List<int>();

        // ��ư 3�� ����
        for (int i = 0; i < 3; i++)
        {
            int buttonIndex;

            loopNum = 0;
            // �ߺ����� ���� ������ �ε��� ã��
            do
            {
                buttonIndex = UnityEngine.Random.Range(0, 10);
                if (loopNum >= 100)
                { // ������ �ʹ� ���� �� ��쿡 ���� ������ �����ϱ� ���� �����մϴ�.
                    Debug.LogError("��ư ������ ������ �߻��߽��ϴ�. ������ �ʹ� ���� ���ҽ��ϴ�.");
                    break;
                }
            } while (uniqueIndices.Contains(buttonIndex));

            // ã�� �ε����� ����Ʈ�� �߰�
            uniqueIndices.Add(buttonIndex);

            ////////////////// �߰� ///////////////////////
            if (buttonIndex >= 5)
            {
                itemArray[i] = IM.checkInstantiate(buttonIndex % 5, true, this.gameObject);
            }
            else
            {
                itemArray[i] = IM.checkInstantiate(buttonIndex, false, this.gameObject);
            }

            ////////////////// �߰� ///////////////////////

            // ��ư ������ Instantiate
            buttonObjects[i] = Instantiate(allButtons[buttonIndex],
                buttonPosition, Quaternion.identity);
            // ĵ������ �ڽ����� �����ؼ� ȭ�鿡 ���̰�
            buttonObjects[i].transform.SetParent(transform);


            ////////////////// ���õ��� �ִ� ������ �̸� ���� ���� ///////////////////////
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


            ////////////////// �߰� ///////////////////////
            buttonPosition.x += 480;    // ���� ��ư ��ġ ����
        }
    }

    ////////////////// �߰� ///////////////////////
    public void onItemButton1()
    {
        Debug.Log("Click1");
        IM.selectItem(itemArray[0]);

        // ���ӸŴ����� �ִ� ����Ʈ�� ������ �������ߴ��� ����
        //gameManagerInstance = FindObjectOfType<GameManager>();
        //gameManagerInstance.itemIndices.Add(item.itemname);


        // ������ ���� ĵ���� ���ֱ�
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }

        // �ð��帧 �ٽ� �ǵ�����
        Time.timeScale = 1;
        Cursor.visible = false; // Ŀ�� �Ⱥ��̰�
        Cursor.lockState = CursorLockMode.Locked;   // Ŀ�� �ȿ����̰�
        ShowItemUI();
        FindImageHolder();
    }

    public void onItemButton2()
    {
        Debug.Log("Click2");
        IM.selectItem(itemArray[1]);

        // ���ӸŴ����� �ִ� ����Ʈ�� ������ �������ߴ��� ����
        //gameManagerInstance = FindObjectOfType<GameManager>();
        //gameManagerInstance.itemIndices.Add(item.itemname);


        // ������ ���� ĵ���� ���ֱ�
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }

        // �ð��帧 �ٽ� �ǵ�����
        Time.timeScale = 1;
        Cursor.visible = false; // Ŀ�� �Ⱥ��̰�
        Cursor.lockState = CursorLockMode.Locked;   // Ŀ�� �ȿ����̰�
        ShowItemUI();
        FindImageHolder();
    }

    public void onItemButton3()
    {
        Debug.Log("Click3");
        IM.selectItem(itemArray[2]);

        // ���ӸŴ����� �ִ� ����Ʈ�� ������ �������ߴ��� ����
        //gameManagerInstance = FindObjectOfType<GameManager>();
        //gameManagerInstance.itemIndices.Add(item.itemname);


        // ������ ���� ĵ���� ���ֱ�
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }

        // �ð��帧 �ٽ� �ǵ�����
        Time.timeScale = 1;
        Cursor.visible = false; // Ŀ�� �Ⱥ��̰�
        Cursor.lockState = CursorLockMode.Locked;   // Ŀ�� �ȿ����̰�
        ShowItemUI();
        FindImageHolder();
    }
    public void ButtonAttackSpeed()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add("AttSpd");
        playerStat = PlayerStat.instance;
        playerStat.AttSpd -= 0.1f;
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
        Cursor.visible = false; // Ŀ�� �Ⱥ��̰�
        Cursor.lockState = CursorLockMode.Locked;   // Ŀ�� �ȿ����̰�
        FindImageHolder();
        ShowItemUI();
    }
    public void ButtonCriticalPower()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add("Cridmg");
        playerStat = PlayerStat.instance;
        playerStat.Cridmg += 0.2f;
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
        Cursor.visible = false; // Ŀ�� �Ⱥ��̰�
        Cursor.lockState = CursorLockMode.Locked;   // Ŀ�� �ȿ����̰�
        FindImageHolder();
        ShowItemUI();
    }
    public void ButtonCriticalProbability()
    {
        gameManagerInstance = FindObjectOfType<GameManager>(); 
        gameManagerInstance.itemIndices.Add("Cri");
        playerStat = PlayerStat.instance;
        playerStat.Cri += 0.15f;
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
        Cursor.visible = false; // Ŀ�� �Ⱥ��̰�
        Cursor.lockState = CursorLockMode.Locked;   // Ŀ�� �ȿ����̰�
        FindImageHolder();
        ShowItemUI();
    }
    public void ButtonDoubleJump()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add("JumpCount");
        playerStat = PlayerStat.instance;
        playerStat.JumpCount += 1;
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
        Cursor.visible = false; // Ŀ�� �Ⱥ��̰�
        Cursor.lockState = CursorLockMode.Locked;   // Ŀ�� �ȿ����̰�
        FindImageHolder();
        ShowItemUI();
    }
    public void ButtonHpRegen()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add("HPregen");
        playerStat = PlayerStat.instance;
        playerStat.HPregen += 1;
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
        Cursor.visible = false; // Ŀ�� �Ⱥ��̰�
        Cursor.lockState = CursorLockMode.Locked;   // Ŀ�� �ȿ����̰�
        FindImageHolder();
        ShowItemUI();
    }
    public void ButtonJumpPower()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add("Jump");
        playerStat = PlayerStat.instance;
        playerStat.Jump += 0.03f;
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
        Cursor.visible = false; // Ŀ�� �Ⱥ��̰�
        Cursor.lockState = CursorLockMode.Locked;   // Ŀ�� �ȿ����̰�
        FindImageHolder();
        ShowItemUI();
    }
    public void ButtonMaxHp()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add("MaxHP");
        playerStat = PlayerStat.instance;
        playerStat.MaxHP += 20;  
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
        Cursor.visible = false; // Ŀ�� �Ⱥ��̰�
        Cursor.lockState = CursorLockMode.Locked;   // Ŀ�� �ȿ����̰�
        FindImageHolder();
        ShowItemUI();
    }
    public void ButtonMoveSpeed()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add("Speed");
        playerStat = PlayerStat.instance;
        playerStat.Speed += 3;
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
        Cursor.visible = false; // Ŀ�� �Ⱥ��̰�
        Cursor.lockState = CursorLockMode.Locked;   // Ŀ�� �ȿ����̰�
        FindImageHolder();
        ShowItemUI();
    }
    public void ButtonShield()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add("Barrier");
        playerStat = PlayerStat.instance;
        playerStat.Barrier += 40;
        ItemSelectCanvas = GameObject.Find("Canvas_ItemSelect(Clone)");
        if (ItemSelectCanvas != null)
        {
            Destroy(ItemSelectCanvas);
        }
        Time.timeScale = 1;
        Cursor.visible = false; // Ŀ�� �Ⱥ��̰�
        Cursor.lockState = CursorLockMode.Locked;   // Ŀ�� �ȿ����̰�
        FindImageHolder();
        ShowItemUI();
    }

    public void ShowItemUI()
    {
        // �����ִ� ���Ӹ޴����� ����
        gameManagerInstance = FindObjectOfType<GameManager>();

        for (int i = 0; i < gameManagerInstance.itemIndices.Count; i++)
        {
            switch (gameManagerInstance.itemIndices[i])
            {
                case "Dmg":
                    itemSpriteHolder2[i].sprite = ItemSprites2[0];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case "AttSpd":
                    itemSpriteHolder2[i].sprite = ItemSprites2[1];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case "Cridmg":
                    itemSpriteHolder2[i].sprite = ItemSprites2[2];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case "Cri":
                    itemSpriteHolder2[i].sprite = ItemSprites2[3];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case "JumpCount":
                    itemSpriteHolder2[i].sprite = ItemSprites2[4];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case "HPregen":
                    itemSpriteHolder2[i].sprite = ItemSprites2[5];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case "Jump":
                    itemSpriteHolder2[i].sprite = ItemSprites2[6];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case "MaxHP":
                    itemSpriteHolder2[i].sprite = ItemSprites2[7];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case "Speed":
                    itemSpriteHolder2[i].sprite = ItemSprites2[8];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
                case "Barrier":
                    itemSpriteHolder2[i].sprite = ItemSprites2[9];
                    itemSpriteHolder2[i].color = Color.white;
                    break;
            }
        }
    }

    void FindImageHolder()
    {
        // Canvas ���� �ִ� Panel�� ã���ϴ�.
        InventoryCanvas = GameObject.Find("Canvas_wave,time,item");
        Transform panelTransform = InventoryCanvas.transform.Find("Panel_Item");
        if (panelTransform != null)
        {            
            // Panel ������ ��� �ڽ� ������Ʈ�� ã�� �迭�� �����մϴ�.
            int childCount = panelTransform.childCount;
            Debug.Log(childCount);
            itemSpriteHolder2 = new Image[childCount];
            for (int i = 0; i < childCount; i++)
            {
                itemSpriteHolder2[i] = panelTransform.GetChild(i).GetComponent<Image>();
            }
        }
        else
        {
            Debug.LogError("Panel�� ã�� �� �����ϴ�.");
        }
    }
}
