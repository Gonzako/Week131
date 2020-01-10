using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{
    public abstract GameManager _GameManager { get; set; }
    public abstract Type Tick();
    public virtual void OnStateEnter() {}
    public virtual void OnStateExit() {}

    public GameState(GameManager _gm)
    {
        _GameManager = _gm;
    }
}
