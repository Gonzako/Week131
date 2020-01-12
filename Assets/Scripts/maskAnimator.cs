/*
 *
 * Copyright (c) Gonzako
 * Gonzako123@gmail.com
 *
 */

using System;
using System.Linq;
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
    Sides side = new Sides();
    private Camera cam;
    Vector2 mouseVector;
    private const string walkingVariable = "Walking";
    private const string moveX = "moveX";
    private const string moveY = "moveY";

    
    #region GarbageSavers
    Vector3 mouseDirVector;
    float mouseAngle;
    #endregion
    #endregion

    #region Public Methods
    public void updateMask(BasicScriptableMask data, GameObject player)
    {
        leftMask.GetComponent<SpriteRenderer>().sprite = data.sideMask;
        rightMask.GetComponent<SpriteRenderer>().sprite = data.sideMask;
        backMask.GetComponent<SpriteRenderer>().sprite = data.backMask;
        frontMask.GetComponent<SpriteRenderer>().sprite = data.frontMask;

    }
    #endregion

    #region Private Methods
    //gets called every frame
    private void updateAnimator()
    {
        AM.SetBool(walkingVariable, walking);
        mouseVector = DegreeToVector2(getAngleTowardsMouse());

        mouseVector = Vector2Int.RoundToInt(mouseVector);
        if(mouseVector.magnitude > 1 ) { mouseVector.y = 0; }
        else { mouseVector.x = 0; }

        Debug.Log(mouseVector);
        if(mouseVector != Vector2.zero)
        {
            AM.SetFloat(moveX, mouseVector.x);
            AM.SetFloat(moveY, mouseVector.y);
        }

    }

    private float getAngleTowardsMouse()
    {
        mouseDirVector = Input.mousePosition - cam.WorldToScreenPoint(transform.position);
        return Mathf.Atan2(mouseDirVector.y, mouseDirVector.x) * Mathf.Rad2Deg;

    }

    //might move this into a extension one
    public  Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    public  Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }
    #endregion


#if true
    #region Unity API
    private void Start()
    {
        cam = Camera.main;
    }
    void OnEnable()
    {
        gunManager.onMaskChange += updateMask;
        AM = GetComponent<Animator>();
        
    }
    private void OnDisable()
    {
        gunManager.onMaskChange -= updateMask;
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


/// <summary>
/// Beware the side order also incurs priority
/// </summary>
internal enum Sides
{
    Down,Left, Right, Up = 0
}