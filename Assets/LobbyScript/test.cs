using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; //OnPointerEnter를 실행하기 위한 전처리기?

public class test : MonoBehaviour, IPointerEnterHandler //OnPointerEnter를 실행하기 위한 전처리기?

{
    public void OnPointerEnter(PointerEventData eventData)
    {
      Debug.Log("OnPointerEnter 함수 발동");
    }
}
