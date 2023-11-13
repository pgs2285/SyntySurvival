using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(FieldOfView)), RequireComponent(typeof(NavMeshAgent)), RequireComponent(typeof(CharacterController))]
public abstract class EnemyController : MonoBehaviour
{
    #region Variables

    public StateMachine<EnemyController> stateMachine;
    protected NavMeshAgent agent;
    protected Animator animator;

    private FieldOfView fov;

    public Transform Target => fov.NearestTarget;
    public LayerMask TargetMask => fov.targetMask;
    public virtual bool IsAvailableAttack => false;
    #endregion Variables
    
    #region Unity Methods

    protected virtual void Start()
    {         
        stateMachine = new StateMachine<EnemyController>(this, new IdleState());

        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
        agent.updateRotation = true;

        animator = GetComponent<Animator>();
        fov = GetComponent<FieldOfView>();
    }

    protected virtual void Update()
    {
        stateMachine.Update(Time.deltaTime);
        
    }
    #endregion Unity Methods
}
