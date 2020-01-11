/*
 *
 * Copyright (c) Gonzako
 * Gonzako123@gmail.com
 *
 */

using System;
using UnityEngine;

public class maskAnimator : MonoBehaviour
{
    #region Public Fields
    #endregion

    #region Private Fields
    [SerializeField]
    GameObject leftMask, rightMask, backMask, frontMask;

    Animator AM;
    bool walking => Mathf.Abs(Input.GetAxisRaw("Horizontal")) + Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0;

    private const string walkingVariable = "Walking";
    #endregion

    #region Public Methods
    public void updateMask(BasicScriptableMask data)
    {

    }
    #endregion

    #region Private Methods

    private void updateAnimator()
    {
        AM.SetBool(walkingVariable, walking);
    }
    #endregion


    #if true
    #region Unity API

    void Start()
    {
        AM = GetComponent<Animator>();
    }

    private void Update()
    {
        updateAnimator();
    }


    void FixedUpdate()
    {
    }

    #endregion
    #endif
 
}