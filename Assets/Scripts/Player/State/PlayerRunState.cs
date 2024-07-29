using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerStatBase
{

    public override void EnterState()
    {
        base.EnterState();

        playerController.PlayAnimation("Run3");
    }

    public override void Update()
    {
        base.Update();

        if (playerController.IsFollow) return;

        playerController.transform.Translate(Vector3.forward * Time.deltaTime * playerController.speed);
        playerController.transform.forward = Vector3.Lerp(
            playerController.transform.forward, movePos, Time.deltaTime * playerController.rotateSpeed);

        if (movePos == Vector3.zero)
        {
            playerController.SwitchState(PlayerState.Idle);
        }
    }


}
