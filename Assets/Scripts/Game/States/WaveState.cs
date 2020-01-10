using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveState : GameState
{
    public WaveState(GameManager _gm) : base(_gm)
    {
        _GameManager = _gm;
    }

    public int _wavenumber;
    public override GameManager _GameManager { get; set; }

    private bool _EnemiesDefeated;


    public override void OnStateEnter()
    {
        _wavenumber += 1;

    }

    public override Type Tick()
    {
        if (_EnemiesDefeated)
        {
            return typeof(ShopState);
        }
        return null;
    }

    public void setEnemiesDefeated()
    {
        _EnemiesDefeated = true;
    }

}
