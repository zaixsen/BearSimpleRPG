using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopModel : Singleton<ShopModel>
{
    List<ShopData> shopDatas;
    ShopController shopController;
    int gridCount;
    public ShopModel()
    {
        gridCount = 36;
        shopDatas = ConfigManager.Instance.shopDatas;
    }

    public void Classify(EquipType equipType)
    {
        List<ShopData> tempLis = new List<ShopData>();
        if (equipType == EquipType.All)
        {
            MessageCenter<List<ShopData>>.Instance.Dispatch(MessageId.CLASSIFY_SHOP, shopDatas);
            return;
        }
        foreach (var shopData in shopDatas)
        {
            if (shopData.equipType == equipType)
            {
                tempLis.Add(shopData);
            }
        }
        MessageCenter<List<ShopData>>.Instance.Dispatch(MessageId.CLASSIFY_SHOP, tempLis);
    }

    public void InitShopView()
    {
        MessageCenter<int>.Instance.Dispatch(MessageId.INIT_SHOP_GRID, gridCount);
        MessageCenter<List<ShopData>>.Instance.Dispatch(MessageId.CLASSIFY_SHOP, shopDatas);
    }

}
