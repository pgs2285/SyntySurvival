using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : State<EnemyController>
{
    #region Variables

    private Animator animator;
    private CharacterController characterController;
    private NavMeshAgent agent;
    
    
    private int moveHash = Animator.StringToHash("Move");
    private int moveSpeedHash = Animator.StringToHash("MoveSpeed");

    #endregion Variables
    
    #region Methods

    public override void OnInitialized()
    {
        animator = context.GetComponent<Animator>();
        characterController = context.GetComponent<CharacterController>();
        agent = context.GetComponent<NavMeshAgent>();
    }

    public override void OnEnter()
    {
        
        agent?.SetDestination(context.Target.position);
        animator?.SetBool(moveHash, true);
    }

    public override void Update(float deltaTime)
    {
        Transform enemy = context.Target;
        if (enemy)
        {
            agent.SetDestination(enemy.position);
            if (agent.remainingDistance > agent.stoppingDistance)
            {
                characterController.Move(agent.velocity * deltaTime);
                animator.SetFloat(moveSpeedHash, agent.velocity.magnitude / agent.speed , .1f, deltaTime); // magnitude 는 벡터의 크기를 리턴한다.
                return;
            }

            stateMachine.ChangeState<IdleState>();
        }
    }

    public override void OnExit()
    {
        agent.ResetPath();
        animator?.SetBool(moveHash,false);
    }
    #endregion Methods
}
