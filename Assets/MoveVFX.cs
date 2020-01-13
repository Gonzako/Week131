/*
 *
 * Copyright (c) Gonzako
 * Gonzako123@gmail.com
 *
 */
 
using UnityEngine;
 
public class MoveVFX : MonoBehaviour
{
    #region Public Fields
    public ParticleSystem startMovePuff;
    #endregion

    #region Private Fields
    movementAnimator movAnim;
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void handleMoveStart(Vector2 direction)
    {
        startMovePuff.transform.position = transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180;
        startMovePuff.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        startMovePuff.Play();
    }
    #endregion


    #if true
    #region Unity API

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

    #endregion
    #endif
 
}