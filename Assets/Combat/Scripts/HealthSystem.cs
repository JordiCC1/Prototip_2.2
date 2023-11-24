using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public event EventHandler OnDead;
    public event EventHandler OnDamaged;

    [SerializeField] private int health = 100;
    [SerializeField] private Unit unit;
    private int healthMax;


    private void Awake()
    {
        if (!unit.IsEnemy())
        { 
            health += PlayerPrefs.GetInt("healthBonus");
            healthMax = health;
        }
        else
        {
            healthMax = health;
        }
    
    }

    
    public void Damage(int damageAmount)
    {
        health -= damageAmount;

        if(health < 0)
        {
            health = 0;
        }

        OnDamaged?.Invoke(this, EventArgs.Empty);

        if (health == 0) 
        {
            Die();
        }
    }

    private void Die() 
    { 
        OnDead?.Invoke(this, EventArgs.Empty);
    }

    public float GetHealthNormalized()
    {
        return ((float)health) / ((float)healthMax);
    }
}
