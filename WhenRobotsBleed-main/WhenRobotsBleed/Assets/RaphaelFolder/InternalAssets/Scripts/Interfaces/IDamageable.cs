using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IDamageable {
    void TakeDamage(float damageAmount);

    void Die();

    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
}