using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private GameState _currentState;

    private GameState _nextState;

    Dictionary<Type, GameState> _availableStates;

    public event Action<GameState> onStateChanged;

    void Update()
    {
        if (_currentState == null && _availableStates != null)
        {
            SwitchToNewState(_availableStates.Keys.First());
        }

        //Take in next state
        var nextState = _currentState?.Tick();

        if (nextState != null && nextState != _currentState?.GetType())
        {
            SwitchToNewState(nextState);
        }
    }


    /// <summary>
    /// Sets currently available states
    /// </summary>
    /// <param name="states"></param>
    public void SetStates(Dictionary<Type, GameState> states)
    {
        Debug.Log("Set State");
        this._availableStates = states;
    }

    /// <summary>
    /// Switches to new state in the state dictionary
    /// </summary>
    /// <param name="nextstate"></param>
    void SwitchToNewState(Type nextstate)
    {
        _currentState?.OnStateExit();
        _currentState = _availableStates[nextstate];
        onStateChanged?.Invoke(_currentState);
        _currentState?.OnStateEnter();
        gamestatetring = _currentState.ToString();
        Debug.Log("Game State Changed To: "+_currentState.ToString());
    }
}
