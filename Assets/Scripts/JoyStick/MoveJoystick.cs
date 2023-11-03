using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform rect;
    public RectTransform handle;
    private float halfWidth;
    Vector2 touch = Vector2.zero;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        halfWidth = rect.sizeDelta.x * 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        touch = (eventData.position - rect.anchoredPosition) / halfWidth;// anchoredPosition : 부모의 좌표계에서의 위치를 eventData.position에서 빼주면 값은 -1 ~ 1 사이의 값이 나온다.
        handle.anchoredPosition = touch * halfWidth;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}
