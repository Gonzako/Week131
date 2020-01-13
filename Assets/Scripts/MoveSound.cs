using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSound : MonoBehaviour
{ 
    movementAnimator movAnim;

    private void handleMoveStart(Vector2 direction)
    {
        Debug.Log("POOP");
    }


    void Start()
    {
    }

    private void OnEnable()
    {
        movAnim = GetComponent<movementAnimator>();
        movAnim.onMovementStart += handleMoveStart;
    }

    private void OnDisable()
    {
        movAnim.onMovementStart -= handleMoveStart;
    }
    void FixedUpdate()
    {
    }
}
