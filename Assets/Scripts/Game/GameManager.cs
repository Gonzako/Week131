using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameStateManager))]
public class GameManager : MonoBehaviour
{
    private GameStateManager _StateHandler;

    public GameSettings _GameSettings;

    public delegate void GameEvents();
    public GameEvents onGameFailure;

    private bool _shoppingDone;

    public int _currentWave = 0;

    private void OnEnable()
    {
        SetupStates();
   
        _shoppingDone = false;
        
    }

    private void OnDisable()
    {
       
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
}