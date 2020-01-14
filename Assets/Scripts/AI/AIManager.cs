using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Pathfinding;

public class AIManager : MonoBehaviour
{
    private Dictionary<Type, BaseAIState> _initialStates;
    private AIStateManager _aistatemng;
    public Seeker _agent;
    public AILerp _lerp;
    public AIDestinationSetter _setter;
    public Rigidbody2D _rb;

    [SerializeField] public Transform _player;

    

    private void OnEnable()
    {
        SetupStates();
    }

    private void Start()
    {
        SetupStates();
        _agent = GetComponent<Seeker>();
        _lerp = GetComponent<AILerp>();
        _setter = GetComponent<AIDestinationSetter>();
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
