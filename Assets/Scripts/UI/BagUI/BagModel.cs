using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagModel : Singleton<BagModel>
{
    List<BagData> bagDatas;
    int gridCount;

    public BagModel()
    {
        bagDatas = ConfigManager.Instance.bagDatas;
        gridCount = 28;
    }

    public void ShowBagData()
    {
        MessageCenter<List<BagData>>.Instance.Dispatch(MessageId.SHOW_BAG_DATA, bagDatas);
    }

    public void InitView()
    {
        MessageCenter<int>.Instance.Dispatch(MessageId.INIT_BAG_GRID, gridCount);
        MessageCenter<List<BagData>>.Instance.Dispatch(MessageId.SHOW_BAG_DATA, bagDatas);
    }

    public void RemoveBagData(BagData bagData)
    {
        bagDatas.Remove(bagData);
        ShowBagData();
    }

}
