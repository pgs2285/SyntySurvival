using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State<EnemyController>
{
    private Animator animator;
    private CharacterController characterController;

    protected int hashMove = Animator.StringToHash("Move");
    protected int hashMoveSpeed = Animator.StringToHash("MoveSpeed");

    public override void OnInitialized()
    {
        animator = context.GetComponent<Animator>();
        characterController = context.GetComponent<CharacterController>();
    }

    public override void OnEnter()
    {
        animator?.SetBool(hashMove, false);
        characterController?.Move(Vector3.zero);
    }

    public override void Update(float deltaTime)
    {
        Transform enemy = context.Target;
        if (enemy != null)
        {
            if (context.IsAvailableAttack)
            {
                // stateMachine.ChangeState<AttackState>();
            }
            else
            {
                stateMachine.ChangeState<MoveState>();
            }
        }
    }
}
