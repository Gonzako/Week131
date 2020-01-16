using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReadyManager : MonoBehaviour
{
    public delegate void ReadyEvents();
    public static ReadyEvents onPlayerReady;

    private GameStateManager _gsm;
    bool _CanPrompt;

   
    private void OnEnable()
    {
        _gsm = FindObjectOfType<GameStateManager>();
        _gsm.onStateChanged += CanPrompt;
    }

    private void OnDisable()
    {
        _gsm.onStateChanged -= CanPrompt;
    }

    // Update is called once per frame
    void Update()
    {
        if (_CanPrompt)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                onPlayerReady?.Invoke();
            }
        }
    }

    void CanPrompt(GameState state)
    {
        if (state.GetType() == typeof(ShopState))
        {
            _CanPrompt = true;
        }
        else
            _CanPrompt = false;
    }
}
