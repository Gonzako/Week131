using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSound : MonoBehaviour
{ 
    movementAnimator movAnim;
    AudioSource audioSource;

    private void handleMoveStart(Vector2 direction)
    {
        audioSource.Play(); 
    }


    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
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
