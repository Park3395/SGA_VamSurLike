using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentsRightPanel : MonoBehaviour
{
    private ItemSelect itemSelectInstance;

    //public List<string> itemIndices = new List<string>();

    public Image[] itemSpriteHolder;
    public Sprite[] ItemSprites;

    private GameManager gameManagerInstance;

    void Start()
    {
        // 씬에있는 게임메니저로 접근
        gameManagerInstance = FindObjectOfType<GameManager>();

        for (int i = 0; i < gameManagerInstance.itemIndices.Count; i++)
        {
            switch (gameManagerInstance.itemIndices[i])
            {
                case "Dmg":
                    itemSpriteHolder[i].sprite = ItemSprites[0];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case "AttSpd":
                    itemSpriteHolder[i].sprite = ItemSprites[1];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case "Cridmg":
                    itemSpriteHolder[i].sprite = ItemSprites[2];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case "Cri":
                    itemSpriteHolder[i].sprite = ItemSprites[3];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case "JumpCount":
                    itemSpriteHolder[i].sprite = ItemSprites[4];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case "HPregen":
                    itemSpriteHolder[i].sprite = ItemSprites[5];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case "Jump":
                    itemSpriteHolder[i].sprite = ItemSprites[6];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case "MaxHP":
                    itemSpriteHolder[i].sprite = ItemSprites[7];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case "Speed":
                    itemSpriteHolder[i].sprite = ItemSprites[8];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case "Barrier":
                    itemSpriteHolder[i].sprite = ItemSprites[9];
                    itemSpriteHolder[i].color = Color.white;
                    break;
            }
        }
    }

    void Update()
    {        
    }
}
