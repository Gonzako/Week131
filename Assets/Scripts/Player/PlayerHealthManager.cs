using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private Image _healthImage;
    private Mortal playerMortal;

    private void OnEnable()
    {
        playerMortal = GetComponent<Mortal>();
        playerMortal.onHit += UpdateHealthUI;
    }

    public void UpdateHealthUI(int amount, int health, int maxhealth)
    {
        Debug.Log("health conv " + 
            (health - amount) / maxhealth);
        float fill = ((float)health - (float)amount) / (float)maxhealth;


        _healthImage.fillAmount = fill; 
          
    }
}
