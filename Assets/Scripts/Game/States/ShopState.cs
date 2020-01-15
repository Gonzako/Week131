using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopState : GameState
{
    public ShopState(GameManager _gm) : base(_gm){
        _GameManager = _gm;
    }

    float _shoptimer;

    public override GameManager _GameManager {get; set;}

    public override void OnStateEnter()
    {
        _shoptimer = _GameManager._GameSettings._ShopTime;
        _GameManager._GameSettings._shop.SetActive(true);
        _GameManager._GameSettings._timerHudTxt.enabled = true;
    }

    public override void OnStateExit()
    {
        _GameManager._GameSettings._shop.SetActive(false);
    }

    public override Type Tick()
    {
        _shoptimer -= Time.deltaTime;
        _GameManager._GameSettings._timerHudTxt.text =
            "Shopping time will end in.. " + Mathf.Round(_shoptimer).ToString();

        if (_shoptimer <= 0)
        {
            return typeof(CountdownState);
        }
        return null;
    }
}
