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
    public BasicScriptableMask Mask { get { return mask; } set {mask.disposeData(); mask = value; mask.prepareData(); onMaskChange.Invoke(value, this.gameObject); } }


    /// <summary>
    /// Gameobject is the gunManager's gameobject
    /// </summary>
    public static event Action<BasicScriptableMask, GameObject> onMaskChange;

    /// <summary>
    /// Gameobject is bullet
    /// </summary>
    public static event Action<BasicScriptableMask, GameObject> onFire;
    public Transform firingPosition;


    #endregion

    #region Private Fields
    private GameObject latestBullet;
    private Camera _cam;
    private Vector2 mouseDirVector;
    private float angle;
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
        mask.prepareData();
    }
 
    void FixedUpdate()
    {
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            angle = getAngleTowardsMouse();
            latestBullet = Mask.Fire(firingPosition, angle);
            if(latestBullet != null)
                onFire?.Invoke(mask, latestBullet);
        }
    }

    #endregion
#endif

}