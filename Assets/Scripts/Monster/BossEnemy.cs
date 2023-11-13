using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : EnemyController
{
#region Unity Methods

    protected override void Start()
    {
        base.Start();
        stateMachine.AddState(new MoveState());
        
    }

    protected override void Update()
    {
        base.Update();
    }

#endregion Unity Methods
}
