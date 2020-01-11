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
    [MinMaxSlider(-90, 90)]
    public MinMax frontAngle;
    [MinMaxSlider(0, 180)]
    public MinMax rightAngle;
    [MinMaxSlider(-180, 0)]
    public MinMax leftAngle;
    [MinMaxSlider(90, 270)]
    public MinMax backAngle;
    #endregion

    #region Private Fields
    [SerializeField]
    GameObject leftMask, rightMask, backMask, frontMask;

    Animator AM;
    bool walking => Mathf.Abs(Input.GetAxisRaw("Horizontal")) + Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0;

    private const string walkingVariable = "Walking";
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
    }
    #endregion


    #if true
    #region Unity API

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