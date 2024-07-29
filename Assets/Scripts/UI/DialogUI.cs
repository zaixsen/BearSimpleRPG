using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour, IPointerClickHandler
{

    public Text speakerText;
    public Text ContentrText;
    GoData npcData;
    public void SetDialog(GoData goData)
    {
        npcData = goData;
        speakerText.text = goData.npcType.ToString();
        switch (goData.npcType)
        {
            case NpcType.Shop:
                ContentrText.text = "您需要购买物品吗 ？";
                break;
            case NpcType.Task:
                if (PlayerController.Instance.killEnemyCount >= 2)
                {
                    ContentrText.text = "完成任务！！！";
                    return;
                }
                ContentrText.text = "熊大 这有暴打熊二的任务 快去吧 ！";
                break;
            default:
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.SetActive(false);
        switch (npcData.npcType)
        {
            case NpcType.Shop:
                //打开商店界面
                UIManager.Instance.SetShopUI(true);
                break;
            case NpcType.Task:
                if (PlayerController.Instance.killEnemyCount >= 2)
                {
                    gameObject.SetActive(false);
                    PlayerController.Instance.killEnemyCount = 0;
                    return;
                }
                //弹出任务窗口
                UIManager.Instance.SetTaskUI(true);
                break;
            default:
                break;
        }
    }
}
