using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Idle, Patrol, Attack, Follow, Dead
}

public class EnemyController : MonoBehaviour, IStateMachineOwner
{
    StateMachine stateMachine;

    EnemyState enemyState;

    Animator animator;

    public Transform player;

    public Vector3 startPos;
    public float gravity;

    private void Start()
    {
        stateMachine = new StateMachine(this);
        animator = GetComponent<Animator>();
        SwitchState(EnemyState.Idle);
        player = PlayerController.Instance.transform;
        startPos = transform.position;
    }

    public void SwitchState(EnemyState enemyState)
    {
        this.enemyState = enemyState;
        switch (enemyState)
        {
            case EnemyState.Idle:
                stateMachine.EnterState<EnemyIdleState>();
                break;
            case EnemyState.Patrol:
                stateMachine.EnterState<EnemyPatrolState>();
                break;
            case EnemyState.Attack:
                break;
            case EnemyState.Dead:
                stateMachine.EnterState<EnemyDeadState>();
                break;
            default:
                break;
        }
    }

    public void PlayAnimation(string animationName, float fixedTransilateTime = .25f)
    {
        animator.CrossFadeInFixedTime(animationName, fixedTransilateTime);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }
}
