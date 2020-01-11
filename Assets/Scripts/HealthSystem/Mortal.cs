using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortal : MonoBehaviour, IMortal
{
    public delegate void MortalEvents(GameObject ai);

    public static MortalEvents onAnyDead;
    public static MortalEvents onAnyNpcDead;
    

    private int _HealthPoints;

    [SerializeField]private const int _MaxHealth = 100;

    private void OnEnable()
    {
        _HealthPoints = _MaxHealth;
    }

    public void Damage(int amount)
    {
        if ((_HealthPoints - amount) <= 0)
            onAnyNpcDead?.Invoke(this.gameObject);
        else
            _HealthPoints -= amount;
    }

    public void Heal(int amount)
    {
        throw new System.NotImplementedException();
    }

    public bool isDead()
    {
        throw new System.NotImplementedException();
    }
}
