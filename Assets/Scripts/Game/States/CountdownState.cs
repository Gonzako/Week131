using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownState : GameState
{
    public CountdownState(GameManager _gm) : base(_gm)
    {
        _GameManager = _gm;
    }

    public override GameManager _GameManager { get; set; }

    public override Type Tick()
    {
        return null;
    }
}
