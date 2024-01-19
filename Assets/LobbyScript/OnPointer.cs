using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//���콺 Ŀ�� ����� ��ũ��Ʈ
public class OnPointer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler //OnPointer �Լ����� �ߵ� ��Ű�� ���� ��... �����ؾߵǳ�
{
    public Texture2D on_cursorIcon;       //������ ���� ���콺�� �÷��� �� ���콺 Ŀ��
    public Texture2D original_cursorIcon; //�����ܿ��� ���콺�� ���� �� ���콺 Ŀ��
    
    //������ ���� ���콺�� �÷��� ��
    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(on_cursorIcon, Vector2.zero, CursorMode.Auto);
    }

    //������ ������ ���콺�� ���� ��
    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(original_cursorIcon, Vector2.zero, CursorMode.Auto);
    }
}


