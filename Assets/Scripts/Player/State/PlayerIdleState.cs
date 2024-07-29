using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerStatBase
{

    public override void EnterState()
    {
        base.EnterState();
        playerController.PlayAnimation("Idle");
    }

    public override void Update()
    {
        base.Update();

     
        #region ºÏ≤‚“∆∂Ø

        if (movePos != Vector3.zero)
        {
            playerController.SwitchState(PlayerState.Run);
        }

        #endregion

    }




}
