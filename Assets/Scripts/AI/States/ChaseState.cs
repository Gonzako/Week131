using System;
using UnityEngine;

public class ChaseState : BaseAIState
{
    public ChaseState(AIManager ai) : base(ai)
    {
        _ai = ai;
    }

    public override AIManager _ai { get; set; }

    private GameObject _Player;

    public override void OnStateEnter()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
    }

    public override Type Tick()
    {

        _ai._trgmngr.target = _Player.transform;
        
  
        return null;
    }
}