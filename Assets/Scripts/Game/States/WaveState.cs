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

    public override GameManager _GameManager { get; set; }

    public override Type Tick()
    {
        return null;
    }
}
