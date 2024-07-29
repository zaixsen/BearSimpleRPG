using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyStateBase
{
    Vector3 targetPos;
    float MaxPatrolDistance;
    float minChangeDis;
    public override void EnterState()
    {
        base.EnterState();
        MaxPatrolDistance = 3f;
        minChangeDis = 0.3f;

        Vector2 v2Pos = Random.insideUnitCircle * MaxPatrolDistance;
        targetPos = enemyController.startPos + new Vector3(v2Pos.x, 0, v2Pos.y);

        enemyController.transform.LookAt(targetPos);

        enemyController.PlayAnimation("Walk1");
    }

    public override void Update()
    {
        base.Update();
        enemyController.transform.Translate(Vector3.forward * Time.deltaTime);
        //∫ˆ¬‘y÷·
        Vector3 v1 = new Vector3(enemyController.transform.position.x, 0, enemyController.transform.position.z);
        Vector3 v2 = new Vector3(targetPos.x, 0, targetPos.z);
        float dis = Vector3.Distance(v1, v2);

        if (dis <= minChangeDis)
        {
            enemyController.SwitchState(EnemyState.Idle);
        }
    }
}
