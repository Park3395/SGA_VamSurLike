using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; //OnPointerEnter�� �����ϱ� ���� ��ó����?

public class test : MonoBehaviour, IPointerEnterHandler //OnPointerEnter�� �����ϱ� ���� ��ó����?

{
    public void OnPointerEnter(PointerEventData eventData)
    {
      Debug.Log("OnPointerEnter �Լ� �ߵ�");
    }
}
