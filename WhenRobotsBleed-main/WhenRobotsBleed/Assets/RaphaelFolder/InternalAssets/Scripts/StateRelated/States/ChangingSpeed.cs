using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingSpeed : MovementState
{
    public ChangingSpeed(MovementStateMachine movementStateMachine) : base("Changing Speed", movementStateMachine){}
    public override void UpdateLogic(){
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        
        if(Mathf.Abs(_horizontalInput) == 1){
            _stateMachine.ChangeState(_movementStateMachine.fullSpeedState);
        }
        if((Mathf.Abs(_horizontalInput) < Mathf.Epsilon)){
            _stateMachine.ChangeState(_movementStateMachine.idleState);
        }
    }
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 vel = _movementStateMachine.rb.velocity;
        vel.x = _horizontalInput * _movementStateMachine.speed;
        _movementStateMachine.rb.velocity = vel;
    }
}
