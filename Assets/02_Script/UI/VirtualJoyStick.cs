using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoyStick : MonoBehaviour,IBeginDragHandler, IEndDragHandler,IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        // �巡�װ� ������ ���� ó���� ���⿡ ����
        // ��: ���̽�ƽ �ڵ��� �߾����� �ǵ����ų� ���� ��
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        // �巡�װ� ������ ���� ó���� ���⿡ ����
        // ��: ���̽�ƽ �ڵ��� �߾����� �ǵ����ų� ���� ��
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        // �巡�װ� ������ ���� ó���� ���⿡ ����
        // ��: ���̽�ƽ �ڵ��� �߾����� �ǵ����ų� ���� ��
    }
}
