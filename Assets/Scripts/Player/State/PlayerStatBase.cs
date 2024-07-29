using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatBase : StateBase
{
    public PlayerController playerController;
    public Vector3 movePos;
    public override void EnterState()
    {
    }

    public override void ExitState()
    {
    }

    public override void InitStateMachineOwner(IStateMachineOwner owner)
    {
        playerController = owner as PlayerController;
    }

    public override void UnInit()
    {
    }

    public override void Update()
    {
        float x = Joystick.GetAxis("Horizontal");
        float z = Joystick.GetAxis("Vertical");
        movePos = new Vector3(x, 0, z);
    }
}
