using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//마우스 커서 변경용 스크립트
public class OnPointer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler //OnPointer 함수들을 발동 시키기 위한 어... 뭐라해야되냐
{
    public Texture2D on_cursorIcon;       //아이콘 위에 마우스를 올렸을 때 마우스 커서
    public Texture2D original_cursorIcon; //아이콘에서 마우스를 땠을 때 마우스 커서
    
    //아이콘 위에 마우스를 올렸을 때
    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(on_cursorIcon, Vector2.zero, CursorMode.Auto);
    }

    //아이콘 위에서 마우스를 땠을 때
    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(original_cursorIcon, Vector2.zero, CursorMode.Auto);
    }
}


