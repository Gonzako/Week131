using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameStateManager))]
public class GameManager : MonoBehaviour
{
    private GameStateManager _StateHandler;
    private ShopViewManager _shopManager;

    public delegate void GameEvents();
    public GameEvents onGameFailure;

    private bool _shoppingDone;

    private void OnEnable()
    {
        SetupStates();
        _shopManager = GameObject.FindObjectOfType<ShopViewManager>();
        _shoppingDone = false;
        _shopManager.onShoppingDone += SetShouldSwitch;
    }

    private void OnDisable()
    {
       _shopManager.onShoppingDone -= SetShouldSwitch;
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

    public void SetShouldSwitch()
    {
        _shoppingDone = true;
    }

    public bool ShoppingDone()
    {
        return _shoppingDone;
    }
}