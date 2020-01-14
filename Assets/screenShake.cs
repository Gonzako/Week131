/*
 *
 * Copyright (c) Gonzako
 * Gonzako123@gmail.com
 *
 */
 
using UnityEngine;
using DG.Tweening;

public class screenShake : MonoBehaviour
{
    #region Public Fields
    public Ease kickUpEase;
    public Ease fallbackEase;

    public float kickStrengh, kickTime, fallbackDur;
    #endregion

    #region Private Fields
    Tween kickUpTween;
    Tween fallbackTween;
    Camera cam;
    Sequence fovKickSequence;
    float defSize;
    #endregion

    #region Public Methods
    public void fovKick(float kickStrengh, float kickTime, float fallbackDuration)
    {
        fovKickSequence = DOTween.Sequence();
        kickUpTween = DOTween.To(() => cam.orthographicSize, x => cam.orthographicSize = x, cam.orthographicSize + kickStrengh, kickTime).SetEase(kickUpEase);
        fovKickSequence.Append(kickUpTween)
            .Append(fallbackTween = DOTween.To(() => cam.orthographicSize, x => cam.orthographicSize = x, defSize, fallbackDuration).SetEase(fallbackEase));
        
    }
    #endregion

    #region Private Methods
    #endregion


#if true
    #region Unity API

    void Start()
    {
        cam = GetComponent<Camera>();
        defSize = cam.orthographicSize;
    }
 
    void FixedUpdate()
    {
    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(10, 10, 150, 100), "fovKickTest"))
        {
            //playsound
            fovKick(kickStrengh, kickTime, fallbackDur);
        }
    }
    #endregion
#endif

}