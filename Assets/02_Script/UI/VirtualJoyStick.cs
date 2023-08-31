using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoyStick : MonoBehaviour,IBeginDragHandler, IEndDragHandler,IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        // 드래그가 끝났을 때의 처리를 여기에 구현
        // 예: 조이스틱 핸들을 중앙으로 되돌리거나 정지 등
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그가 끝났을 때의 처리를 여기에 구현
        // 예: 조이스틱 핸들을 중앙으로 되돌리거나 정지 등
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        // 드래그가 끝났을 때의 처리를 여기에 구현
        // 예: 조이스틱 핸들을 중앙으로 되돌리거나 정지 등
    }
}
