using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum PlayerState
{
    Idle, Run
}

public class PlayerController : MonoSingleton<PlayerController>, IStateMachineOwner
{

    StateMachine stateMachine;

    PlayerState playerState;

    Animator animator;
    public NavMeshAgent meshAgent;

    public float speed;
    public float rotateSpeed;
    public float gravity;
    public bool IsFollow;
    //»÷É±ÊýÁ¿
    public int killEnemyCount;

    private void Start()
    {
        stateMachine = new StateMachine(this);
        animator = GetComponent<Animator>();
        meshAgent = GetComponent<NavMeshAgent>();
        SwitchState(PlayerState.Idle);
        speed = 5;
        rotateSpeed = 10;
        IsFollow = false;
    }

    public void SwitchState(PlayerState playerState)
    {
        this.playerState = playerState;
        switch (playerState)
        {
            case PlayerState.Idle:
                stateMachine.EnterState<PlayerIdleState>();
                break;
            case PlayerState.Run:
                stateMachine.EnterState<PlayerRunState>();
                break;
            default:
                break;
        }
    }

    public void PlayAnimation(string animationName, float fixedTransilateTime = .25f)
    {
        animator.CrossFadeInFixedTime(animationName, fixedTransilateTime);
    }

    public void SetDestanition(Vector3 pos, bool isfollow)
    {
        IsFollow = isfollow;
        meshAgent.SetDestination(pos);
        targetPos = pos;
        SwitchState(PlayerState.Run);
    }
    Vector3 targetPos;
    private void Update()
    {
        stateMachine.currentState.Update();

        if (IsFollow)
        {
            float dis = Vector3.Distance(transform.position, targetPos);
            if (dis < 0.5f)
            {
                SwitchState(PlayerState.Idle);
                meshAgent.isStopped = true;
                IsFollow = false;
            }
        }

        //if (IsFollow)
        //{
        //    if (meshAgent.stoppingDistance < 0.5f)
        //    {
        //        SwitchState(PlayerState.Idle);
        //        meshAgent.isStopped = true;
        //        IsFollow = false;
        //    }
        //    else
        //    {
        //        SwitchState(PlayerState.Run);
        //    }
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goods"))
        {
            ShopData shopData = other.GetComponent<GoodsItem>().shopData;
            MessageCenter<ShopData>.Instance.Dispatch(MessageId.ADD_BAG_DATA, shopData);
            Destroy(other.gameObject);
        }
    }

}
