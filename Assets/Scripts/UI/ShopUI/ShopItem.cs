using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IPointerClickHandler
{
    public ShopView view;
    public Image icon;
    ShopData data;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (data != null)
        {
            view.SetTipInfo(data);
        }
    }

    public void SetData(ShopData shopData)
    {
        data = shopData;
        icon.gameObject.SetActive(shopData != null);
        if (shopData != null)
            icon.sprite = Resources.Load<Sprite>(shopData.iconPath);
    }
}
