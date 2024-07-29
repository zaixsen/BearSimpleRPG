using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyStateBase
{
    public override void EnterState()
    {
        base.EnterState();
        string deadStr = Random.Range(0, 2) == 1 ? "Death1" : "Death2";
        enemyController.PlayAnimation(deadStr);
        PlayerController.Instance.killEnemyCount++;
        ShopData shopData = ConfigManager.Instance.GetShopData();
        var goods = GameObject.Instantiate(Resources.Load<SpriteRenderer>(PathManager.GOODS_DISCARD));
        goods.transform.position = enemyController.transform.position;
        goods.sprite = Resources.Load<Sprite>(shopData.iconPath);
        goods.GetComponent<GoodsItem>().SetData(shopData);
    }

    public override void Update()
    {
        base.Update();

    }

}
