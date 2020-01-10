using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopState : GameState
{
    public ShopState(GameManager _gm) : base(_gm){
        _GameManager = _gm;
    }

    public override GameManager _GameManager {get; set;}

    public override void OnStateEnter()
    {
   
    }

    public override void OnStateExit()
    {
    }

    public override Type Tick()
    {
        if (_GameManager.ShoppingDone())
        {
            return typeof(CountdownState);
        }
        return null;
    }
}
