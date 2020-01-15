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
    public BasicScriptableMask Mask { get { return mask; } set { mask = value; onMaskChange.Invoke(value, this.gameObject); mask.ResetTimer(); } }

    public static event Action<BasicScriptableMask, GameObject> onMaskChange;
    public Transform firingPosition;


    #endregion

    #region Private Fields
    private Camera _cam;
    private Vector2 mouseDirVector;
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private float getAngleTowardsMouse()
    {
        mouseDirVector = Input.mousePosition - _cam.WorldToScreenPoint(transform.position);
        return Mathf.Atan2(mouseDirVector.y, mouseDirVector.x) * Mathf.Rad2Deg;

    }
    #endregion


#if true
    #region Unity API

    void Start()
    {
        _cam = Camera.main;
        Mask.ResetTimer();
    }
 
    void FixedUpdate()
    {
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Mask.Fire(transform, getAngleTowardsMouse());
        }
    }

    #endregion
#endif

}