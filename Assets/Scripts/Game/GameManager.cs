﻿using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameStateManager))]
public class GameManager : MonoBehaviour
{
    private GameStateManager _StateHandler;

    public GameSettings _GameSettings;

    public delegate void GameEvents(int waves);
    public static GameEvents onGameFailure;

    public delegate void GameNPCEvents(int amount);
    public GameNPCEvents onShouldSpawnEnemies;

    private bool _shoppingDone;

    public int _currentWave = 0;

    private void OnEnable()
    {
        SetupStates();
   
        _shoppingDone = false;
        Mortal.onAnyDead += PlayerDeath;
        
        
    }

    private void OnDisable()
    {
        Mortal.onAnyDead -= PlayerDeath;
    }

    private void SetupStates()
    {
        _StateHandler = GetComponent<GameStateManager>();
        Dictionary<Type, GameState> states = new Dictionary<Type, GameState> {
            {typeof(ShopState), new ShopState(this)},
            {typeof(CountdownState), new CountdownState(this)},
            {typeof(WaveState), new WaveState(this)},
        };
        _StateHandler.SetStates(states);
    }

    public bool ShoppingDone()
    {
        return _shoppingDone;
    }

    private void PlayerDeath(Mortal m)
    {
        if(m.tag == "Player")
        {
            onGameFailure?.Invoke(_currentWave);
        }
    }


}