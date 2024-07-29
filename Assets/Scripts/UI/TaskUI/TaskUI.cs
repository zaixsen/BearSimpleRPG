using UnityEngine;
using UnityEngine.UI;

public class TaskUI : MonoBehaviour
{
    TaskData data;

    public Text taskName;
    public Text taskDes;
    public Button followButton;
    public Button closeButton;
    private void Start()
    {
        data = ConfigManager.Instance.taskDatas[0];
        taskName.text = data.name;
        taskDes.text = data.des;
        Vector3 pos = new Vector3(data.x, data.y, data.z);
        followButton.onClick.AddListener(() =>
        {
            PlayerController.Instance.SetDestanition(pos, true);
            UIManager.Instance.SetTaskUI(false);
        });
        closeButton.onClick.AddListener(() => UIManager.Instance.SetTaskUI(false));
    }
}
