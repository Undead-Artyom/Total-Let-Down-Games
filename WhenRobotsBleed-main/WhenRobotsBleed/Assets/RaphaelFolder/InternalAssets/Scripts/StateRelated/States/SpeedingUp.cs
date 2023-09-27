using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedingUp : MovementState
{
    private float _lastHorizontalInput = 0f;
    public SpeedingUp(MovementStateMachine movementStateMachine) : base("Speeding Up", movementStateMachine){}
    public override void UpdateLogic(){
        base.UpdateLogic();
        _horizontalInput = Mathf.Abs(Input.GetAxis("Horizontal"));
        if(_horizontalInput == 1)
        {
            _stateMachine.ChangeState(_movementStateMachine.fullSpeedState);
        }
        if(_horizontalInput < _lastHorizontalInput)
        {
            _stateMachine.ChangeState(_movementStateMachine.slowingDownState);
        }
        _lastHorizontalInput = _horizontalInput;
    }
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 vel = _movementStateMachine.rb.velocity;
        vel.x = Input.GetAxis("Horizontal") * _movementStateMachine.speed;
        _movementStateMachine.rb.velocity = vel;
    }
}
