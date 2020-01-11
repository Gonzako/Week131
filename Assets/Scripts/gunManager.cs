/*
 *
 * Copyright (c) Gonzako
 * Gonzako123@gmail.com
 *
 */

using System;
using UnityEngine;
 
public class gunManager : MonoBehaviour
{
    #region Public Fields
    [SerializeField]
    private BasicScriptableMask mask;
    public BasicScriptableMask Mask { get { return mask; } set { mask = value; onMaskChange.Invoke(value, this.gameObject); } }

    public static event Action<BasicScriptableMask, GameObject> onMaskChange;
    public Transform firingPosition;
    #endregion
 
    #region Private Fields
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
 
    void FixedUpdate()
    {
    }

    #endregion
    #endif
 
}