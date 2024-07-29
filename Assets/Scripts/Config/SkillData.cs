public class SkillData
{
    public int id;
    public string iconPath;
    public string skillPath;
    public int atk;
}

public enum EquipType
{
    All, Weapon, Drug, Prop
}
public enum ButtonType
{
    Button1, Button2, Button3,
}
public class ShopData
{
    public int id;
    public string name;
    public string iconPath;
    public string description;
    public EquipType equipType;
    public ButtonType buttonType;
}
public class BagData
{
    public ShopData shopData;
    public int count;
}
public class TaskData
{
    public int id;
    public string name;
    public string des;
    public bool isfinish;
    public float x;
    public float y;
    public float z;
}