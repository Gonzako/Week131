using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Pathfinding;

public class AIManager : MonoBehaviour
{
    private Dictionary<Type, BaseAIState> _initialStates;
    private AIStateManager _aistatemng;
    public AIDestinationSetter _trgmngr;

    

    private void OnEnable()
    {
        SetupStates();
    }

    private void Start()
    {
        SetupStates();
        _trgmngr = GetComponent<AIDestinationSetter>();
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
