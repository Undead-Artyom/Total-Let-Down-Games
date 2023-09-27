using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected BaseState _currentState;

    public BaseState currentState => _currentState;

//Publically accessable method for other objects to tell this state machine object to change its state

//Two objects should be able to resolve their interaction by themselves, without the need of a manager

//Due to this, if one object successfully hits and drops the others health to zero, it should be able
//to tell the other object to kill itself

//Love the non-coupling with passing in the newState

    public void ChangeState(BaseState newState)
    {
        _currentState.ExitState();
        _currentState = newState;
        _currentState.EnterState();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }
    void Start()
    {
        _currentState = GetInitialState();
        if (currentState != null){
            currentState.EnterState();
        }
    }

    void Update()
    {
        Debug.Log(Input.GetAxis("Horizontal"));
        if(currentState != null){
            currentState.UpdateLogic();
        }
    }
    void LateUpdate()
    {
        if(currentState != null){
            currentState.UpdatePhysics();
        }
    }
    private void OnGUI()
    {
        string content = currentState != null ? currentState.name : "{no current state}";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
    }
    
}
