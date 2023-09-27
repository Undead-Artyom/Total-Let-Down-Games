using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullSpeed : MovementState
{
    public FullSpeed(MovementStateMachine movementStateMachine) : base("Full Speed", movementStateMachine){}
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Mathf.Abs(Input.GetAxis("Horizontal"));
        if(_horizontalInput < 1){
            stateMachine.ChangeState(_movementStateMachine.slowingDownState);
        }
        // transition to "idle" state if input = 0
    }
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 vel = _movementStateMachine.rb.velocity;
        vel.x = Input.GetAxis("Horizontal") * _movementStateMachine.speed;
        _movementStateMachine.rb.velocity = vel;
    }
}

