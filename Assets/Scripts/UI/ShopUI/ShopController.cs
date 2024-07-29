using System;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    ShopModel model;

    private void Start()
    {
        model = ShopModel.Instance;
        model.InitShopView();
    }

    public void CloseUI()
    {
        UIManager.Instance.SetShopUI(false);
    }

    public void Classify(int equipType)
    {
        model.Classify((EquipType)equipType);
    }
}
