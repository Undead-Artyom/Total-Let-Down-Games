using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : BaseState
{
    protected MovementStateMachine _movementStateMachine;
    protected float _horizontalInput;
    public MovementState(string name, MovementStateMachine movementStateMachine) : base(name, movementStateMachine){
        _movementStateMachine = (MovementStateMachine)_stateMachine;
    }
    public override void EnterState(){
        base.EnterState();
        _horizontalInput = 0f;
    }
    public override void UpdateLogic(){
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
    }

    public override void ExitState(){
        base.ExitState();
    }
}
