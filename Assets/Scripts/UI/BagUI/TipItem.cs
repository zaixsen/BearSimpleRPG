using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TipItem : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public BagView view;

    public void OnPointerEnter(PointerEventData eventData)
    {
        view.SetTipActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        view.SetTipActive(false);
    }
}
