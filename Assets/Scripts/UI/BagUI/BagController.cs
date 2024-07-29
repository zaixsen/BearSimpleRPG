using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    public BagModel model;
    public BagView view;

    private void Start()
    {
        model = BagModel.Instance;
        model.InitView();
    }

    private void OnEnable()
    {
        if (model != null)
        {
            model.ShowBagData();
        }
    }

    public void CloseUI()
    {
        UIManager.Instance.SetBagUI(false);
    }

}
