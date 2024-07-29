using System;
using System.Collections.Generic;
using UnityEngine;

public class MessageCenter<T> : Singleton<MessageCenter<T>>
{
    Dictionary<int, Action<T>> dic_msgs = new Dictionary<int, Action<T>>();

    public void AddListener(int msgId, Action<T> action)
    {
        if (dic_msgs.ContainsKey(msgId))
        {
            dic_msgs[msgId] += action;
        }
        else
        {
            dic_msgs.Add(msgId, action);
        }
    }

    public void Dispatch(int msgId, T t)
    {
        if (dic_msgs.ContainsKey(msgId))
        {
            dic_msgs[msgId]?.Invoke(t);
        }
        else
        {
            Debug.LogError(msgId + " not register");
        }
    }
}
