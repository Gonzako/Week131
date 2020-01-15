/*
 *
 * Copyright (c) Gonzako
 * Gonzako123@gmail.com
 *
 */

using System;
using UnityEngine;

public class gameplayDisabler : MonoBehaviour
{
    #region Public Fields
    public GameObject playerGuy;
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

    private void OnEnable()
    {
        ShopInteractable.onAnyOpenCommand += disableOrEnable;
    }

    private void OnDisable()
    {
        ShopInteractable.onAnyOpenCommand -= disableOrEnable;
    }

    private void disableOrEnable()
    {
        playerGuy.SetActive(!playerGuy.activeSelf);
    }

    void FixedUpdate()
    {
    }

    #endregion
    #endif
 
}