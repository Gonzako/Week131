/*
 *
 * Copyright (c) Gonzako
 * Gonzako123@gmail.com
 *
 */
 
using UnityEngine;
 
public class followMouse : MonoBehaviour
{
    #region Public Fields
    #endregion

    #region Private Fields
    private Camera cam;
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion


    #if true
    #region Unity API

    void Start()
    {
        cam = Camera.main;
    }
 
    void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(cam.transform.position.z);
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    #endregion
    #endif
 
}