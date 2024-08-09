using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagView : MonoBehaviour
{
    public BagController bagController;
    public BagItem bagItemTemp;
    public Image equipTemp;
    public Button closeButton;
    public GameObject tipGo;
    List<BagItem> bagItems;
    List<Image> equipIcons;

    //Tip
    public Image tipIcon;
    public Text tipNameText;
    public Button[] tipButton;

    private void Awake()
    {
        bagItems = new List<BagItem>();
        equipIcons = new List<Image>();
        MessageCenter<List<BagData>>.Instance.AddListener(MessageId.SHOW_BAG_DATA, ShowBagData);
        MessageCenter<int>.Instance.AddListener(MessageId.INIT_BAG_GRID, InitBagGrid);
        closeButton.onClick.AddListener(bagController.CloseUI);
    }

    public void SetTipInfo(BagData bagData)
    {
        SetTipActive(true);
        tipGo.transform.position = Input.mousePosition;
        for (int i = 0; i < tipButton.Length; i++)
            tipButton[i].onClick.RemoveAllListeners();
        Sprite sprite = Resources.Load<Sprite>(bagData.shopData.iconPath);
        tipIcon.sprite = sprite;
        tipNameText.text = bagData.shopData.name;

        switch (bagData.shopData.buttonType)
        {
            case ButtonType.Button1:
                tipButton[0].GetComponentInChildren<Text>().text = "×°±¸";
                tipButton[0].onClick.AddListener(() => equipIcons[0].sprite = sprite);
                tipButton[1].GetComponentInChildren<Text>().text = "¶ªÆú";
                tipButton[1].onClick.AddListener(() =>
                {
                    var sr = Instantiate(Resources.Load<SpriteRenderer>(PathManager.GOODS_DISCARD));
                    sr.GetComponent<GoodsItem>().SetData(bagData.shopData);
                    sr.sprite = sprite;
                    sr.transform.position = PlayerController.Instance.transform.position + Vector3.left;
                    BagModel.Instance.RemoveBagData(bagData);
                });
                break;
            case ButtonType.Button2:
                tipButton[0].GetComponentInChildren<Text>().text = "";
                tipButton[1].GetComponentInChildren<Text>().text = "";
                break;
            case ButtonType.Button3:
                tipButton[0].GetComponentInChildren<Text>().text = "";
                tipButton[1].GetComponentInChildren<Text>().text = "";
                break;
            default:
                break;
        }

    }

    private void ShowBagData(List<BagData> list)
    {
        for (int i = 0; i < bagItems.Count; i++)
        {
            if (i < list.Count)
            {
                bagItems[i].SetData(list[i]);
            }
            else
            {
                bagItems[i].SetData(null);
            }
        }
    }

    private void InitBagGrid(int gridCount)
    {
        for (int i = 0; i < gridCount; i++)
        {
            var item = Instantiate(bagItemTemp, bagItemTemp.transform.parent);
            bagItems.Add(item);
            item.SetData(null);
        }

        for (int i = 0; i < 4; i++)
        {
            var item = Instantiate(equipTemp, equipTemp.transform.parent);
            equipIcons.Add(item);
        }
        bagItemTemp.gameObject.SetActive(false);
    }

    public void SetTipActive(bool active)
    {
        tipGo.SetActive(active);
    }
}
