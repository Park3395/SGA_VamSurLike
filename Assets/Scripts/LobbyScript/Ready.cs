using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Ready : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler //OnPointer �Լ����� �ߵ� ��Ű�� ���� ��... �����ؾߵǳ�
{
    public GameObject now_difficulty;
    //�� ��ȯ
   public void OnClick()
   {
        SceneManager.LoadScene("jhscene 1");
   }
    //�غ� ������ ���� ���콺�� �÷��� ��
    public void OnPointerEnter(PointerEventData eventData)
    {
        now_difficulty.SetActive(true);
    }

    //�غ� ������ ������ ���콺�� ���� ��
    public void OnPointerExit(PointerEventData eventData)
    {
        now_difficulty.SetActive(false);
    }
}
