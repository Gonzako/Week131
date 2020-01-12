/*
 *
 * Copyright (c) Gonzako
 * Gonzako123@gmail.com
 *
 */

using System; 
using UnityEngine;
 
public class movementAnimator : MonoBehaviour
{
    #region Public Fields
    public event Action<Vector2> onMovementStart;
    #endregion

    #region Private Fields
    bool walking => Mathf.Abs(Input.GetAxisRaw("Horizontal")) + Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0;
    bool previousWalking = false;
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion


#if true
    #region Unity API

    void Start()
    {
    }
 
    void Update()
    {
        if(walking && previousWalking)
        {
            onMovementStart?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        }
    }

    #endregion
#endif

}