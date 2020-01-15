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


    private Path path;
    private bool isFinished = false;
    int currentWaypoint = 0;
    public float _calculationFrequency = 1F;
    private float timer;

    

    public override void OnStateEnter()
    {
  
        //_ai._agent.StartPath(_ai.transform.position, _Player.transform.position, OnPathComplete);
    }


    private void OnPathComplete(Path p)
    {
        Debug.Log(p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
       
    }
    
    private void RecalculatePath()
    {
        if (timer < Time.time)
        {
            if (_ai._agent.IsDone())
            {
               // _ai._agent.StartPath(_ai.transform.position, _Player.transform.position, OnPathComplete);
                
                timer = Time.time + _calculationFrequency;

            }
        }
    }

    public override Type Tick()
    {
        Vector2 dir = _ai._player.transform.position - _ai.transform.position;

        dir.Normalize();


   
        if (path == null)
        {
           // Debug.LogError("Path is null" + _ai.gameObject.name);
        }

        _ai._rb.AddForce(dir * _ai._settings._movementSpeed);
  
        return null;
    }
}


