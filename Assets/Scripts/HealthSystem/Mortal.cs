﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortal : MonoBehaviour, IMortal
{
    public delegate void MortalEvents(Mortal ai);

    public static MortalEvents onAnyDead;
    public static MortalEvents onAnyNpcDead;
    

    [SerializeField]private int _HealthPoints;

    [SerializeField]private const int _MaxHealth = 100;

    private void OnEnable()
    {
        _HealthPoints = _MaxHealth;
    }

    public void Damage(int amount)
    {
        if ((_HealthPoints - amount) <= 0)
        {
            _HealthPoints = 0;
            if (gameObject.tag == "NPC")
            {
                onAnyNpcDead?.Invoke(this);
                this.gameObject.SetActive(false);
            }
            else
                onAnyDead?.Invoke(this);
        }
        else
            _HealthPoints -= amount;
    }

    public void Heal(int amount)
    {
        throw new System.NotImplementedException();
    }

    public bool isDead()
    {
        return (_HealthPoints <= 0);       
    }
}
