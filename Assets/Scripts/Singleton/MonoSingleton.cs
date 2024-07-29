using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    public static T Instance;
    public virtual void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError(this+"not Single mode , maby create other instance");
        }
        Instance = this as T;
    }
}
