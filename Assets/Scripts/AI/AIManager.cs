using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Pathfinding;

public class AIManager : MonoBehaviour
{
    private Dictionary<Type, BaseAIState> _initialStates;
    private AIStateManager _aistatemng;
    public Rigidbody2D _rb;
    [SerializeField] public AISettings _settings;

    public Transform _player;

    

    private void OnEnable()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        SetupStates();
    }

    private void Start()
    {
        SetupStates();

        _rb = GetComponent<Rigidbody2D>();
    }

    private void SetupStates()
    {
        _aistatemng = GetComponent<AIStateManager>();
        _initialStates = new Dictionary<Type, BaseAIState>
        {
            {typeof(ChaseState), new ChaseState(this)}
        };
        _aistatemng.SetStates(_initialStates);
    }
}

