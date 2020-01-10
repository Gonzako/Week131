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

    private float _timer;

    public override void OnStateEnter()
    {
        _timer = _GameManager._GameSettings._ShopTime;

    }

    public override void OnStateExit()
    {
        _GameManager._GameSettings._timerHudTxt.enabled = false;
    }

    public override Type Tick()
    {
        _timer -= Time.deltaTime;
        _GameManager._GameSettings._timerHudTxt.text =
          "Next wave will start in.. " + Mathf.Round(_timer).ToString();
        if (_timer <= 0)
            return typeof(WaveState);
        else
        return null;
    }
}
