using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BagView view;
    public Image icon;
    BagData data;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (data != null)
            view.SetTipInfo(data);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       //view.SetTipActive(false);
    }

    public void SetData(BagData bagData)
    {
        data = bagData;
        icon.gameObject.SetActive(bagData != null);

        if (bagData != null)
            icon.sprite = Resources.Load<Sprite>(bagData.shopData.iconPath);
    }
}
