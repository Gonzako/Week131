using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameSettings
{

    [Header("Shopping Settings")]
    [SerializeField] public float _ShopTime = 10F; //10 Seconds

    [Header("Wave Settings")]
    [SerializeField] public float _countdownTime = 5F;



    [Header("IN GAME HUD ELEMENTS")]
    [SerializeField] public Text _timerHudTxt;
}
