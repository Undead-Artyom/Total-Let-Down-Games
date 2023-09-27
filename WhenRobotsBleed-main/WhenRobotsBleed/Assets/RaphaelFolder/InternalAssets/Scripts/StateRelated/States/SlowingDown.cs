using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingDown : MovementState
{
    private float _lastHorizontalInput = 0f;
    public SlowingDown(MovementStateMachine movementStateMachine) : base("Slowing Down", movementStateMachine){}
    public override void UpdateLogic(){
        base.UpdateLogic();
        _horizontalInput = Mathf.Abs(Input.GetAxis("Horizontal"));
        if(_horizontalInput > _lastHorizontalInput)
        {
            _stateMachine.ChangeState(_movementStateMachine.speedingUpState);
        }
        if(_horizontalInput < Mathf.Epsilon)
        {
            _stateMachine.ChangeState(_movementStateMachine.idleState);
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
