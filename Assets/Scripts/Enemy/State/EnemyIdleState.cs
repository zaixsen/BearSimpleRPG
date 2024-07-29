using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyStateBase
{
    float IdleTime;
    float IdleMaxTime = 3;
    public override void EnterState()
    {
        base.EnterState();
        IdleTime = IdleMaxTime;
        enemyController.PlayAnimation("Idle");
    }

    public override void Update()
    {
        base.Update();
        IdleTime -= Time.deltaTime;
        if (IdleTime <= 0)
        {
            IdleTime = IdleMaxTime;
            enemyController.SwitchState(EnemyState.Patrol);
        }
    }
}
