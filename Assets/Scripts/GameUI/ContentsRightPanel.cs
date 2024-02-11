using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentsRightPanel : MonoBehaviour
{
    private ItemSelect itemSelectInstance;  //안쓰는듯

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
                case 0:
                    itemSpriteHolder[i].sprite = ItemSprites[0];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case 1:
                    itemSpriteHolder[i].sprite = ItemSprites[1];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case 2:
                    itemSpriteHolder[i].sprite = ItemSprites[2];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case 3:
                    itemSpriteHolder[i].sprite = ItemSprites[3];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case 4:
                    itemSpriteHolder[i].sprite = ItemSprites[4];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case 5:
                    itemSpriteHolder[i].sprite = ItemSprites[5];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case 6:
                    itemSpriteHolder[i].sprite = ItemSprites[6];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case 7:
                    itemSpriteHolder[i].sprite = ItemSprites[7];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case 8:
                    itemSpriteHolder[i].sprite = ItemSprites[8];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case 9:
                    itemSpriteHolder[i].sprite = ItemSprites[9];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case 10:
                    itemSpriteHolder[i].sprite = ItemSprites[10];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case 11:
                    itemSpriteHolder[i].sprite = ItemSprites[11];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case 12:
                    itemSpriteHolder[i].sprite = ItemSprites[12];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case 13:
                    itemSpriteHolder[i].sprite = ItemSprites[13];
                    itemSpriteHolder[i].color = Color.white;
                    break;
                case 14:
                    itemSpriteHolder[i].sprite = ItemSprites[14];
                    itemSpriteHolder[i].color = Color.white;
                    break;
            }
        }
    }

    void Update()
    {        
    }
}
