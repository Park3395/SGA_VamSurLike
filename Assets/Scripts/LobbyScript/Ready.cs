using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Ready : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler //OnPointer �Լ����� �ߵ� ��Ű�� ���� ��... �����ؾߵǳ�
{
    public GameObject now_difficulty;
    public Text Difficulty;
    //�� ��ȯ
   public void OnClick()
   {
        SceneManager.LoadScene("jhscene 1");
        
   }
    //�غ� ������ ���� ���콺�� �÷��� ��
    public void OnPointerEnter(PointerEventData eventData)
    {
        now_difficulty.SetActive(true);
        if (SelectNormal.instance.active_normal == true)
        {
            Difficulty.text = "���� ���̵��� �����Դϴ�.";
        }

        if(SelectHard.instance.active_hard == true)
        {
            Difficulty.text = "���� ���̵��� ������Դϴ�.";
        }
        
        if(SelectEasy.instance.active_easy == true)
        {
            Difficulty.text = "���� ���̵��� �����Դϴ�.";
        }
          
    }

    //�غ� ������ ������ ���콺�� ���� ��
    public void OnPointerExit(PointerEventData eventData)
    {
        now_difficulty.SetActive(false);
    }
}
