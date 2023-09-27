using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    [SerializeField]
    protected string _name;
    public string name => _name;

    protected StateMachine _stateMachine;
    public StateMachine stateMachine => _stateMachine;

    public BaseState(string name, StateMachine stateMachine){
        this._name = name;
        this._stateMachine = stateMachine;
    }

    public virtual void EnterState(){}
    public virtual void UpdateLogic(){}
    public virtual void UpdatePhysics(){}
    public virtual void ExitState(){}

    /*
    
    Definitely will end up keeping the EnterState and ExitState things.

    Each State should be like a caretaker for the behaviours. When the State Machine tells the State
    that it's changing, the State should tell the behaviours that they need to leave.
    
    */

    /*
    will probably end up replacing updatelogic with something related to behaviours

    public virtual void Update(){

    }
    
    */
}
