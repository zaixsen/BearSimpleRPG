using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GoType
{
    Player, Enemy, NPC, Goods
}
public enum NpcType
{
    Shop, Task
}
public class GoData
{
    public int id;
    public string prefab;
    public string icon;
    public GoType goType;
    public NpcType npcType;
    public float x;
    public float y;
    public float z;
    public GoData(GoType goTyp,int id)
    {
        goType = goTyp;
        this.id = id;
    }
}
