/*
 *
 * Copyright (c) Gonzako
 * Gonzako123@gmail.com
 *
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
 
public class flashRedOnHit : MonoBehaviour
{
    #region Public Fields
    [SerializeField]
    float timeToBackToNorm = 0.2f;

    #endregion

    #region Private Fields
    List<SpriteRenderer> spriteRenderers;
    List<Color> defaultColours;
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void flashRed(GameObject caller)
    {
        for (int i = 0; i < spriteRenderers.Count; i++)
        {
            spriteRenderers[i].color = Color.red;
            StartCoroutine(backToNormalColour(spriteRenderers[i], i));
        } 
    }

    private IEnumerator backToNormalColour(SpriteRenderer n, int index)
    {
        yield return new WaitForSeconds(timeToBackToNorm);
        n.color = defaultColours[index];
    }
    #endregion


    #if true
    #region Unity API

    void OnEnable()
    {
        defaultColours = new List<Color>();
        spriteRenderers = new List<SpriteRenderer>();
        spriteRenderers.Add(GetComponent<SpriteRenderer>());
        spriteRenderers.AddRange(GetComponentsInChildren<SpriteRenderer>());
        foreach(SpriteRenderer n in spriteRenderers)
        {
            defaultColours.Add(n.color);
        }

        AIDamager.onPlayerHit += flashRed;
    }

    private void OnDisable()
    {
        AIDamager.onPlayerHit -= flashRed;
    }


    void FixedUpdate()
    {
    }

    #endregion
    #endif
 
}