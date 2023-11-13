using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State<EnemyController>
{
    private Animator animator;
    private CharacterController characterController;
    private NavMeshAgent agent;
    protected int hashMove = Animator.StringToHash("Move");
    protected int hashMoveSpeed = Animator.StringToHash("MoveSpeed");

    public override void OnInitialized()
    {
        animator = context.GetComponent<Animator>();
        characterController = context.GetComponent<CharacterController>();
        agent = context.GetComponent<NavMeshAgent>();
    }

    public override void OnEnter()
    {
        animator?.SetBool(hashMove, false);
        characterController?.Move(Vector3.zero);
        agent.ResetPath();
        
    }

    public override void Update(float deltaTime)
    {
        Transform enemy = context.Target;
        if (enemy != null)
        {

                stateMachine.ChangeState<MoveState>();
            
        }
        else
        {
            
        }
    }
}
