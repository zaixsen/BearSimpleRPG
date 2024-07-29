using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public Button[] skillButtons;
    public Button talkButton;
    public GameObject dialogPanel;
    public GameObject ShopUI;
    public GameObject BagUI;
    public GameObject TaskUI;


    private void Start()
    {
        for (int i = 0; i < skillButtons.Length; i++)
        {
            skillButtons[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(ConfigManager.Instance.skillDatas[i].iconPath);
            int index = i;
            skillButtons[i].onClick.AddListener(() =>
            {
                SkillCoreManager.Instance.RealeaseSkill(ConfigManager.Instance.skillDatas[index], GameManager.Instance.player, (playableDir) =>
                {
                    for (int i = 0; i < TargetSelected.targets.Count; i++)
                    {
                        TargetSelected.targets[i].GetComponent<EnemyController>().SwitchState(EnemyState.Dead);
                    }
                });
            });
        }

    }

    public void SetShopUI(bool active)
    {
        ShopUI.SetActive(active);
    }

    public void SetBagUI(bool active)
    {
        BagUI.SetActive(active);
    }

    public void SetTaskUI(bool active)
    {
        TaskUI.SetActive(active);
    }

    public void SetNPCButton(GoData npcData, Transform NpcPos, bool active)
    {
        talkButton.onClick.AddListener(() =>
        {
            dialogPanel.SetActive(true);
            dialogPanel.GetComponent<DialogUI>().SetDialog(npcData);
        });

        Vector3 viewPos = Camera.main.WorldToScreenPoint(NpcPos.position + new Vector3(0, -1, 0));
        talkButton.GetComponentInChildren<Text>().text = "Talk";
        talkButton.gameObject.SetActive(active);
        talkButton.transform.position = viewPos;
    }
}
