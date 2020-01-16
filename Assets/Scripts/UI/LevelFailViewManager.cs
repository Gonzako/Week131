using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;
using TMPro;

public class LevelFailViewManager : MonoBehaviour
{

    [SerializeField] UIView _view;
    [SerializeField] TextMeshProUGUI _waveTxt;

    private void OnEnable()
    {

        GameManager.onGameFailure += PlayerDeath;
    }

    private void OnDisable()
    {
        GameManager.onGameFailure -= PlayerDeath;
    }

    void PlayerDeath(int waves)
    {
        _waveTxt.text = "Waves Survived "+waves.ToString();
        _view.Show();
    }
}
