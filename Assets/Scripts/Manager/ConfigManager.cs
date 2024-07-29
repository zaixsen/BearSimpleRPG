using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : Singleton<ConfigManager>
{
    public List<GoData> GoDatas;
    public List<SkillData> skillDatas;
    public List<ShopData> shopDatas;
    public List<BagData> bagDatas;
    public List<TaskData> taskDatas;

    public ConfigManager()
    {
        //½âÎöjson±í
        try
        {
            GoDatas = JsonConvert.DeserializeObject<List<GoData>>(
                Resources.Load<TextAsset>(PathManager.SCENE_DATA_PATH).text);
            skillDatas = JsonConvert.DeserializeObject<List<SkillData>>(
                Resources.Load<TextAsset>(PathManager.SKILL_DATA_PATH).text);
            shopDatas = JsonConvert.DeserializeObject<List<ShopData>>(
                Resources.Load<TextAsset>(PathManager.SHOP_DATA_PATH).text);
            taskDatas = JsonConvert.DeserializeObject<List<TaskData>>(
                Resources.Load<TextAsset>(PathManager.TASK_DATA_PATH).text);
        }
        catch (System.Exception)
        {
            Debug.LogError("Data Analyse Error");
        }
        bagDatas = new List<BagData>();
        MessageCenter<ShopData>.Instance.AddListener(MessageId.ADD_BAG_DATA, AddBagData);
    }

    public ShopData GetShopData()
    {
        return shopDatas[Random.Range(0, shopDatas.Count)];
    }

    public void AddBagData(ShopData shopData)
    {
        BagData bagData = new BagData()
        {
            shopData = shopData,
            count = 1
        };

        bagDatas.Add(bagData);
    }


}
