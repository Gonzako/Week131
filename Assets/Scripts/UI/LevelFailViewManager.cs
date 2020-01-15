using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;


public class LevelFailViewManager : MonoBehaviour
{

    [SerializeField] UIView _view;
    private void OnEnable()
    {
        Mortal.onAnyDead += PlayerDeath;
    }

    private void OnDisable()
    {
        Mortal.onAnyDead -= PlayerDeath;
    }

    void PlayerDeath(Mortal mortal)
    {
        if(mortal.gameObject.tag == "Player")
        {
            _view.Show();
        }
    }
}
