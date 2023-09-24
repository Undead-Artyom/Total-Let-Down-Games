using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Enemy : MonoBehaviour, IDamageable, IMovable
{
    [SerializeField] protected float _movementSpeed = 100f;

    [field: SerializeField]
    public bool IsFacingRight { get; set; } = true;

    [field: SerializeField]
    public Rigidbody2D RB { get; set; }

    [field: SerializeField]
    public float CurrentHealth { get; set; }

    [field: SerializeField]
    public float MaxHealth { get; set; }

    
    #region State Machine Variables
    
    public EnemyStateMachine StateMachine { get; set; }

    protected EnemyIdleState _idleState { get; set; }
    protected EnemyChaseState _chaseState { get; set; }
    protected EnemyAttackState _attackState { get; set; }

    #endregion


    

    #region Health / Die Methods 

    #endregion

    #region Movement Methods



    #endregion

    #region MonoBehaviour Events
    void Awake()
    {
        CurrentHealth = MaxHealth;
        RB = GetComponent<Rigidbody2D>();
        StateMachine = new EnemyStateMachine();
        _idleState = new EnemyIdleState(this, StateMachine);
        _chaseState = new EnemyChaseState(this, StateMachine);
        _attackState = new EnemyAttackState(this, StateMachine);
    }
    #endregion
}
