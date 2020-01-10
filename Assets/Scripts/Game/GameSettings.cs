﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameSettings
{

    [Header("Shopping Settings")]
    [SerializeField] public float _ShopTime = 10F; //10 Seconds



    [Header("IN GAME HUD ELEMENTS")]
    [SerializeField] public Text _timerHudTxt;
}
