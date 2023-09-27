using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : MovementState
{
    public Idle(MovementStateMachine movementStateMachine) : base("Idle", movementStateMachine){}
    public override void UpdateLogic(){
        base.UpdateLogic();
        _horizontalInput = Mathf.Abs(Input.GetAxis("Horizontal"));
        /*
        
        Leave condition. If this is true, tell the State Machine to change states.
        I'm inclined to believe that States should not have the ability to command the
        State Machine to change states.

        But then again, since the State Machine is the one who calls this method, and not the State itself,
        maybe it's OK. Like the State Machine says to the State:

        "Run your logic for a frame. If any Leave Conditions are met, send me the notification to change the state"

        I said before that objects should be able to resolve their own interactions without intervention, that
        they should be able to communicate between each other to do things on their own.

        State and State Machine cross method calls could count as an interaction object I guess. I'm thinking about the
        what-ifs. What possible scenarios could there be where the State telling the State Machine to change state could cause problems?

        Of course, in the future, when there are persistent and transparent states, if the State tells the State Machine to change to another state,
        and that state happens to be a certain persistent state, the State Machine can instead route things to a specific transition state
        that leads to the intended persistent state, all without the original state knowing about it. They don't care, they just want to leave.
        
        */

        if(_horizontalInput > Mathf.Epsilon){
            _stateMachine.ChangeState(_movementStateMachine.speedingUpState);
        }
        
        /*
        if((Mathf.Abs(_horizontalInput) > Mathf.Epsilon) && (Mathf.Abs(_horizontalInput) < _movementStateMachine.speed)){
            _stateMachine.ChangeState(_movementStateMachine.speedingUpState);
        }
        */
        
    }
}
