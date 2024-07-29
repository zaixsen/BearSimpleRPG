using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler
{
    static RectTransform rectTransform;
    static float radius;
    Vector3 startPos;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        radius = 150;
        startPos = transform.position;
    }
    public static float GetAxis(string axis)
    {
        if (axis == "Horizontal")
        {
            return rectTransform.anchoredPosition.x / radius;
        }
        else if (axis == "Vertical")
        {
            return rectTransform.anchoredPosition.y / radius;
        }
        return 0f;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = startPos + Vector3.ClampMagnitude(Input.mousePosition - startPos, radius);
    }
}
