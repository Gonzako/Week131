using Pathfinding;
using System;
using UnityEngine;

public class ChaseState : BaseAIState
{
    public ChaseState(AIManager ai) : base(ai)
    {
        _ai = ai;
    }

    public override AIManager _ai { get; set; }




    

    public override void OnStateEnter()
    {
  
        //_ai._agent.StartPath(_ai.transform.position, _Player.transform.position, OnPathComplete);
    }


    
 

    public override Type Tick()
    {
        Vector2 dir = _ai._player.transform.position - _ai.transform.position;

        dir.Normalize();


   
    
        _ai._rb.AddForce(dir * _ai._settings._movementSpeed);
  
        return null;
    }
}


