using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IStateMachineOwner { }

public abstract class StateBase
{
    public abstract void InitStateMachineOwner(IStateMachineOwner owner);
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void Update();
    public abstract void UnInit();

}
