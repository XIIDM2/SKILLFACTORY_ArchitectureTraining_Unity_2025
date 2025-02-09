using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform joyStickArea;
    [SerializeField] private RectTransform joyStick;

    public static Vector2 Value {  get; private set; }

    public void OnDrag(PointerEventData eventData)
    {
        Move(eventData.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Move(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joyStick.anchoredPosition = Vector2.zero;
        Value = Vector2.zero;
    }

    private void Move(Vector2 movePosition)
    {
        joyStick.position = movePosition;
        if (joyStick.anchoredPosition.magnitude > joyStickArea.sizeDelta.x / 2)
        {
            joyStick.anchoredPosition = joyStick.anchoredPosition.normalized * (joyStickArea.sizeDelta.x / 2);
        }

        Value = new Vector2(joyStick.anchoredPosition.x, joyStick.anchoredPosition.y).normalized;
    }
}
