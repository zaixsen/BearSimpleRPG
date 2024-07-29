using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnerManager : MonoSingleton<SpawnerManager>
{
    [HideInInspector] public List<GoData> GoDatas;
    [HideInInspector] public List<GameObject> enemies;
    [HideInInspector] public List<GameObject> goods;
    [HideInInspector] public Transform player;
    public Transform parent;
    public override void Awake()
    {
        base.Awake();

        GoDatas = ConfigManager.Instance.GoDatas;

        for (int i = 0; i < GoDatas.Count; i++)
        {
            GameObject go = Instantiate(Resources.Load<GameObject>(GoDatas[i].prefab), parent);
            go.transform.position = new Vector3(GoDatas[i].x, GoDatas[i].y, GoDatas[i].z);
            go.name = GoDatas[i].goType.ToString();
            switch (GoDatas[i].goType)
            {
                case GoType.Player:
                    go.AddComponent<PlayerController>();
                    go.tag = "Player";
                    player = go.transform;
                    break;
                case GoType.Enemy:
                    go.AddComponent<EnemyController>();
                    go.tag = "Enemy";
                    enemies.Add(go);
                    break;
                case GoType.NPC:
                    var headText = Instantiate(Resources.Load<GameObject>("Prefab/Other/HeadText"), go.transform);
                    Animator animator = go.GetComponent<Animator>();
                    animator.CrossFadeInFixedTime("Idle", .25f);
                    headText.GetComponentInChildren<TextMeshProUGUI>().text = GoDatas[i].npcType.ToString();
                    headText.AddComponent<NPC>().InitNPCData(GoDatas[i]);
                    go.transform.eulerAngles = new Vector3(0, 180, 0);
                    break;
                case GoType.Goods:
                    goods.Add(go);
                    break;
            }
        }
    }
}
