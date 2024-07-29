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
                ContentrText.text = "����Ҫ������Ʒ�� ��";
                break;
            case NpcType.Task:
                if (PlayerController.Instance.killEnemyCount >= 2)
                {
                    ContentrText.text = "������񣡣���";
                    return;
                }
                ContentrText.text = "�ܴ� ���б����ܶ������� ��ȥ�� ��";
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
                //���̵����
                UIManager.Instance.SetShopUI(true);
                break;
            case NpcType.Task:
                if (PlayerController.Instance.killEnemyCount >= 2)
                {
                    gameObject.SetActive(false);
                    PlayerController.Instance.killEnemyCount = 0;
                    return;
                }
                //�������񴰿�
                UIManager.Instance.SetTaskUI(true);
                break;
            default:
                break;
        }
    }
}
