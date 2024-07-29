using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public StateBase currentState;

    public bool HasState { get { return currentState != null; } }

    Dictionary<Type, StateBase> dic_states;

    IStateMachineOwner owner;

    public StateMachine(IStateMachineOwner owner)
    {
        this.owner = owner;
        dic_states = new Dictionary<Type, StateBase>();
    }

    public void EnterState<T>() where T : StateBase, new()
    {
        Type type = typeof(T);
        //是否有状态
        if (HasState && type == currentState.GetType()) return;

        //退出状态
        if (HasState) currentState.ExitState();

        //进入状态
        if (!dic_states.TryGetValue(type, out StateBase stateBase))
        {
            stateBase = new T();
            stateBase.InitStateMachineOwner(owner);
            dic_states.Add(type, stateBase);
        }
        currentState = stateBase;
        currentState.EnterState();
    }

    public void ExitState<T>() where T : StateBase, new()
    {
        Type type = typeof(T);
        if (dic_states.ContainsKey(type))
        {
            dic_states[type].ExitState();
        }
    }

    /// <summary>
    /// 销毁状态机
    /// </summary>
    public void Clear()
    {
        dic_states.Clear();
    }

}
