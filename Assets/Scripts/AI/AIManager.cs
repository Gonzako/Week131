using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIManager : MonoBehaviour
{
    private Dictionary<Type, BaseAIState> _initialStates;

    private void OnEnable()
    {
        SetupStates();
    }

    private void SetupStates()
    {
        _initialStates = new Dictionary<Type, BaseAIState>
        {
            {typeof(ChaseState), new ChaseState(this)}
        };
    }
}
