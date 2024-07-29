using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
public class SceneEditor : EditorWindow
{
    static List<GoData> goDatas;

    static string resPath;

    static bool playerFoldout;
    static bool enemyFoldout;
    static bool npcFoldout;
    static bool goodsFoldout;

    static Dictionary<int, GameObject> dic_prefabs = new Dictionary<int, GameObject>();
    static Dictionary<int, Sprite> dic_icons = new Dictionary<int, Sprite>();
    [MenuItem("SceneEditor/SceneEditor")]
    public static void Init()
    {
        resPath = Application.dataPath + "/Resources/";
        try
        {
            goDatas = JsonConvert.DeserializeObject<List<GoData>>(Resources.Load<TextAsset>("Data/sceneData").text);
            dic_prefabs.Clear();
            dic_icons.Clear();
        }
        catch (System.Exception)
        {
            goDatas = new List<GoData>();
        }
        for (int i = 0; i < goDatas.Count; i++)
        {
            dic_icons.Add(goDatas[i].id, Resources.Load<Sprite>(goDatas[i].icon));
        }
        for (int i = 0; i < goDatas.Count; i++)
        {
            dic_prefabs.Add(goDatas[i].id, Resources.Load<GameObject>(goDatas[i].prefab));
        }
        GetWindow<SceneEditor>("SceneEditor").Show();
        playerFoldout = true;
        enemyFoldout = true;
        npcFoldout = true;
        goodsFoldout = true;
    }

    private void OnGUI()
    {
        GUILayout.Space(10);
        GUILayout.Label("场景编辑器");
        //Player
        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        playerFoldout = EditorGUILayout.Foldout(playerFoldout, "Player", false);
        if (GUILayout.Button("Add", GUILayout.Width(80)))
        {
            GoData god = new GoData(GoType.Player, goDatas.Count);
            goDatas.Add(god);
            dic_prefabs.Add(god.id, null);
        }
        GUILayout.EndHorizontal();

        if (playerFoldout)
        {
            for (int i = 0; i < goDatas.Count; i++)
            {
                if (goDatas[i].goType == GoType.Player)
                {
                    //预制体路径
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("Player Id :" + goDatas[i].id);
                    GUILayout.Label("Prefab : ");
                    dic_prefabs[goDatas[i].id] = (GameObject)EditorGUILayout.ObjectField(dic_prefabs[goDatas[i].id], typeof(GameObject), true);

                    string prePath = AssetDatabase.GetAssetPath(dic_prefabs[goDatas[i].id]);

                    prePath = prePath.Replace("Assets/Resources/", "");
                    goDatas[i].prefab = prePath.Replace(".prefab", "");

                    GUILayout.EndHorizontal();

                    //坐标
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("PosX:");
                    goDatas[i].x = EditorGUILayout.FloatField(goDatas[i].x, GUILayout.Width(80));
                    GUILayout.Label("PosY:");
                    goDatas[i].y = EditorGUILayout.FloatField(goDatas[i].y, GUILayout.Width(80));
                    GUILayout.Label("PosZ");
                    goDatas[i].z = EditorGUILayout.FloatField(goDatas[i].z, GUILayout.Width(80));
                    GUILayout.EndHorizontal();

                }
            }
        }

        //Enemy
        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        enemyFoldout = EditorGUILayout.Foldout(enemyFoldout, "Enemy", false);
        if (GUILayout.Button("Add", GUILayout.Width(80)))
        {
            GoData god = new GoData(GoType.Enemy, goDatas.Count);
            goDatas.Add(god);
            dic_prefabs.Add(god.id, null);
        }
        GUILayout.EndHorizontal();

        if (enemyFoldout)
        {
            for (int i = 0; i < goDatas.Count; i++)
            {
                if (goDatas[i].goType == GoType.Enemy)
                {
                    //预制体路径
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("Enemy Id :" + goDatas[i].id);
                    GUILayout.Label("Prefab : ");
                    dic_prefabs[goDatas[i].id] = (GameObject)EditorGUILayout.ObjectField(dic_prefabs[goDatas[i].id], typeof(GameObject), true);

                    string prePath = AssetDatabase.GetAssetPath(dic_prefabs[goDatas[i].id]);

                    prePath = prePath.Replace("Assets/Resources/", "");
                    goDatas[i].prefab = prePath.Replace(".prefab", "");

                    GUILayout.EndHorizontal();

                    //坐标
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("PosX:");
                    goDatas[i].x = EditorGUILayout.FloatField(goDatas[i].x, GUILayout.Width(80));
                    GUILayout.Label("PosY:");
                    goDatas[i].y = EditorGUILayout.FloatField(goDatas[i].y, GUILayout.Width(80));
                    GUILayout.Label("PosZ");
                    goDatas[i].z = EditorGUILayout.FloatField(goDatas[i].z, GUILayout.Width(80));
                    GUILayout.EndHorizontal();
                }
            }
        }
        //NPC
        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        npcFoldout = EditorGUILayout.Foldout(npcFoldout, "NPC", false);
        if (GUILayout.Button("Add", GUILayout.Width(80)))
        {
            GoData god = new GoData(GoType.NPC, goDatas.Count);
            goDatas.Add(god);
            dic_prefabs.Add(god.id, null);
        }
        GUILayout.EndHorizontal();

        if (npcFoldout)
        {
            for (int i = 0; i < goDatas.Count; i++)
            {
                if (goDatas[i].goType == GoType.NPC)
                {
                    //预制体路径
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("NPC Id :" + goDatas[i].id);
                    GUILayout.Label("Prefab : ");
                    dic_prefabs[goDatas[i].id] = (GameObject)EditorGUILayout.ObjectField(dic_prefabs[goDatas[i].id], typeof(GameObject), true);

                    string prePath = AssetDatabase.GetAssetPath(dic_prefabs[goDatas[i].id]);

                    prePath = prePath.Replace("Assets/Resources/", "");
                    goDatas[i].prefab = prePath.Replace(".prefab", "");

                    GUILayout.EndHorizontal();

                    //坐标
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("PosX:");
                    goDatas[i].x = EditorGUILayout.FloatField(goDatas[i].x, GUILayout.Width(80));
                    GUILayout.Label("PosY:");
                    goDatas[i].y = EditorGUILayout.FloatField(goDatas[i].y, GUILayout.Width(80));
                    GUILayout.Label("PosZ");
                    goDatas[i].z = EditorGUILayout.FloatField(goDatas[i].z, GUILayout.Width(80));
                    GUILayout.EndHorizontal();
                    //NPC类型
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("Npc Type :");
                    goDatas[i].npcType = (NpcType)EditorGUILayout.EnumPopup(goDatas[i].npcType);
                    GUILayout.EndHorizontal();

                }
            }
        }

        //Goods
        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        goodsFoldout = EditorGUILayout.Foldout(goodsFoldout, "Goods", false);
        if (GUILayout.Button("Add", GUILayout.Width(80)))
        {
            GoData god = new GoData(GoType.Goods, goDatas.Count);
            goDatas.Add(god);
            dic_prefabs.Add(god.id, null);
            dic_icons.Add(god.id, null);
        }
        GUILayout.EndHorizontal();

        if (goodsFoldout)
        {
            for (int i = 0; i < goDatas.Count; i++)
            {
                if (goDatas[i].goType == GoType.Goods)
                {
                    //预制体路径
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("Goods Id :" + goDatas[i].id);
                    GUILayout.Label("Prefab : ");
                    dic_prefabs[goDatas[i].id] = (GameObject)EditorGUILayout.ObjectField(dic_prefabs[goDatas[i].id], typeof(GameObject), true);

                    string prePath = AssetDatabase.GetAssetPath(dic_prefabs[goDatas[i].id]);

                    prePath = prePath.Replace("Assets/Resources/", "");
                    goDatas[i].prefab = prePath.Replace(".prefab", "");

                    GUILayout.EndHorizontal();
                    //Icon路径
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("Icon : ");

                    dic_icons[goDatas[i].id] = (Sprite)EditorGUILayout.ObjectField(dic_icons[goDatas[i].id], typeof(Sprite), true);

                    string iconPath = AssetDatabase.GetAssetPath(dic_icons[goDatas[i].id]);

                    iconPath = iconPath.Replace("Assets/Resources/", "");
                    goDatas[i].icon = iconPath.Replace(".png", "");

                    GUILayout.EndHorizontal();
                    //坐标
                    GUILayout.BeginHorizontal();
                    GUILayout.Label("PosX:");
                    goDatas[i].x = EditorGUILayout.FloatField(goDatas[i].x, GUILayout.Width(80));
                    GUILayout.Label("PosY:");
                    goDatas[i].y = EditorGUILayout.FloatField(goDatas[i].y, GUILayout.Width(80));
                    GUILayout.Label("PosZ");
                    goDatas[i].z = EditorGUILayout.FloatField(goDatas[i].z, GUILayout.Width(80));
                    GUILayout.EndHorizontal();
                }
            }
        }

        if (GUILayout.Button("保存"))
        {
            string sceneJson = JsonConvert.SerializeObject(goDatas);

            File.WriteAllText(resPath + "Data/sceneData.json", sceneJson);

            AssetDatabase.Refresh();
        }
    }

}
