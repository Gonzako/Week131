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
    bool _playerReady;

    public override GameManager _GameManager {get; set;}

    public override void OnStateEnter()
    {
        _playerReady = false;
        _shoptimer = _GameManager._GameSettings._ShopTime;
        _GameManager._GameSettings._shop.SetActive(true);
        _GameManager._GameSettings._timerHudTxt.enabled = true;
        PlayerReadyManager.onPlayerReady += SetReady;
    }

    public override void OnStateExit()
    {
        _GameManager._GameSettings._shop.SetActive(false);
        PlayerReadyManager.onPlayerReady -= SetReady;
    }

    private void SetReady()
    {
        _playerReady = true;
    }

    public override Type Tick()
    {
        _shoptimer -= Time.deltaTime;
        _GameManager._GameSettings._timerHudTxt.text =
            "Press Space when you are ready for next wave";

        if (_playerReady)
        {
            return typeof(CountdownState);
        }
        return null;
    }
}
