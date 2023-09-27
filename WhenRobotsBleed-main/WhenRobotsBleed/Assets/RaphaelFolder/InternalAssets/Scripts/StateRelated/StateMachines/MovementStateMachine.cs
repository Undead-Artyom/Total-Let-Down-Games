using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementStateMachine : StateMachine
{
    private Idle _idleState;
    public Idle idleState => _idleState;
    private FullSpeed _fullSpeedState;
    public FullSpeed fullSpeedState => _fullSpeedState;

    /*
    private ChangingSpeed _changingSpeedState;
    public ChangingSpeed changingSpeedState => _changingSpeedState;
    */
    
    private SlowingDown _slowingDownState;
    public SlowingDown slowingDownState => _slowingDownState;
    private SpeedingUp _speedingUpState;
    public SpeedingUp speedingUpState => _speedingUpState;
    
    

    private Rigidbody2D _rb;
    public Rigidbody2D rb => _rb;

    [SerializeField]
    private float _speed;
    public float speed => _speed;

    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    void Awake()
    {
        _idleState = new Idle(this);
        _fullSpeedState = new FullSpeed(this);
        //_changingSpeedState = new ChangingSpeed(this);

        _slowingDownState = new SlowingDown(this);
        _speedingUpState = new SpeedingUp(this);
        _rb = GetComponent<Rigidbody2D>();
    }
}
