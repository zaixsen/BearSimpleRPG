using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopView : MonoBehaviour
{
    public ShopController shopController;
    public Button classfiyButtonTemp;
    public Button closeButton;
    public ShopItem shopItemTemp;
    List<ShopItem> shopItems;
    //Tip
    public GameObject tipGo;
    public Image tipIcon;
    public Text tipNameText;
    public Text tipContentText;
    public Button tipBuyButton;

    private void Awake()
    {
        shopItems = new List<ShopItem>();
        MessageCenter<List<ShopData>>.Instance.AddListener(MessageId.CLASSIFY_SHOP, Classify);
        MessageCenter<int>.Instance.AddListener(MessageId.INIT_SHOP_GRID, InitGird);
        closeButton.onClick.AddListener(shopController.CloseUI);
    }

    private void InitGird(int gridCount)
    {
        for (int i = 0; i < gridCount; i++)
        {
            var item = Instantiate(shopItemTemp, shopItemTemp.transform.parent);
            shopItems.Add(item);
            item.SetData(null);
        }
        shopItemTemp.gameObject.SetActive(false);
    }

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            int index = i;
            var btn = Instantiate(classfiyButtonTemp, classfiyButtonTemp.transform.parent);
            btn.GetComponentInChildren<Text>().text = ((EquipType)i).ToString();
            btn.onClick.AddListener(() => shopController.Classify(index));
            btn.gameObject.SetActive(true);
        }
        classfiyButtonTemp.gameObject.SetActive(false);
    }

    public void SetTipInfo(ShopData shopData)
    {
       tipBuyButton.onClick.RemoveAllListeners();
        tipIcon.sprite = Resources.Load<Sprite>(shopData.iconPath);
        tipNameText.text = shopData.name;
        tipContentText.text = shopData.description;
        //·¢ËÍµ½±³°ü
        tipBuyButton.onClick.AddListener(() =>
        {
            MessageCenter<ShopData>.Instance.Dispatch(MessageId.ADD_BAG_DATA, shopData);
        }); 
    }

    private void Classify(List<ShopData> shopDatas)
    {
        for (int i = 0; i < shopItems.Count; i++)
        {
            if (i < shopDatas.Count)
            {
                shopItems[i].SetData(shopDatas[i]);
            }
            else
            {
                shopItems[i].SetData(null);
            }
        }
    }
}
