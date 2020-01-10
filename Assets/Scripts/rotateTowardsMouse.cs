/*
 *
 * Copyright (c) Gonzako
 * Gonzako123@gmail.com
 *
 */

using System;
using UnityEngine;

public class rotateTowardsMouse : MonoBehaviour
{
    #region Public Fields
    public int maxRotateAngle = 15, minRotateAngle = 5;
    #endregion

    #region Private Fields
    Camera mainCam;

    #region GarbaseSabers
    Vector3 screenPos;
    #endregion
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods


    private void rotateToMousePos()
    {
        screenPos = mainCam.WorldToScreenPoint(transform.position);
        Vector3 directionVect = Input.mousePosition - screenPos;
        float angle = Mathf.Atan2(directionVect.y, directionVect.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
    }
    #endregion


#if true
    #region Unity API

    void Start()
    {
        mainCam = Camera.main;
    }
 
    void Update()
    {
        rotateToMousePos();
    }
         
    #endregion
#endif

}