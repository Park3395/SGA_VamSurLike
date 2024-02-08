using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour
{
    public Button[] allButtons;     //�ν����Ϳ��� ��ư������ �ִ°�
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

    [SerializeField]
    ItemManager IM;

    struct ItemData
    {
        public int num;
        public bool isActive;
    }

    ItemData[] buttons;

    ////////////////// �߰� ///////////////////////

    int loopNum;

    void Start()
    {
        ItemButtonInstantiate();

        Cursor.visible = true; // Ŀ�� ���̰�
        Cursor.lockState = CursorLockMode.None;   // Ŀ�� �����̰�

        playerStat = PlayerStat.instance;

    }

    void Update()
    {
    }

    void ItemButtonInstantiate()
    {

        IM = ItemManager.instance;
        buttons = new ItemData[3];
        // ��ư ������ ���� �迭 �ʱ�ȭ
        buttonObjects = new Button[3];

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
            if (buttonIndex > 5)
            {
                buttons[i].isActive = true;
                buttons[i].num = buttonIndex % 5;
            }
            else
            {
                buttons[i].isActive = false;
                buttons[i].num = buttonIndex;
            }
            ////////////////// �߰� ///////////////////////

            Debug.Log(buttons[i].isActive);
            Debug.Log(buttons[i].num);

            // ��ư ������ Instantiate
            buttonObjects[i] = Instantiate(allButtons[buttonIndex],
                buttonPosition, Quaternion.identity);
            // ĵ������ �ڽ����� �����ؼ� ȭ�鿡 ���̰�
            buttonObjects[i].transform.SetParent(transform);


            ////////////////// ���õ��� �ִ� ������ �̸� ���� ���� ///////////////////////
            ItemBase item = IM.selectItem(buttons[i].num,buttons[i].isActive);
            buttonObjects[i].transform.Find("LvText").GetComponent<Text>().text = String.Format("Lv {0} / Lv {1}", item.level, item.maxlevel);

            /////////////////////////////////////////////////////////////////
            

            ////////////////// �߰� ///////////////////////
            buttonPosition.x += 480;    // ���� ��ư ��ġ ����
        }
    }

    ////////////////// �߰� ///////////////////////
    public void onItemButton()
    {
        ItemBase item = new ItemBase();

        if(this == buttonObjects[0])
            item = IM.selectItem(buttons[0].num,buttons[0].isActive);
        else if (this == buttonObjects[1])
            item = IM.selectItem(buttons[1].num, buttons[1].isActive);
        else if (this == buttonObjects[2])
            item = IM.selectItem(buttons[2].num, buttons[2].isActive);

        // ���ӸŴ����� �ִ� ����Ʈ�� ������ �������ߴ��� ����
        gameManagerInstance = FindObjectOfType<GameManager>();
        gameManagerInstance.itemIndices.Add(item.itemname);

        item.getItem();

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
