using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseAIState
{ 
    public  ChaseState(AIManager ai) : base(ai)
    {
        _ai = ai;
    }
    public override AIManager _ai { get; set; }

    public override Type Tick()
    {
        throw new NotImplementedException();
    }
}
