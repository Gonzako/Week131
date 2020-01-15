using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMoneyManager : MonoBehaviour
{

    [SerializeField] private Text _moneytxt;
    [SerializeField] private int _playerMoney = 0;
    private gunManager _gun;

    public delegate void PlayerMoneyEvents(ItemShopMask mask);
    public static PlayerMoneyEvents onReturnMask;

    private void OnEnable()
    {
        //_playerMoney ;
        _gun = GetComponent<gunManager>();
        ItemInformation.onItemBuy += HandleTransaction;
        Mortal.onAnyNpcDead += GotKill;
    }
    private void OnDisable()
    {
        ItemInformation.onItemBuy -= HandleTransaction;
        Mortal.onAnyNpcDead -= GotKill;
    }

   private void HandleTransaction(ItemShopMask mask, GameObject ob)
    {
        if(mask._maskCost < _playerMoney)
        {
            _gun.Mask = mask._power;
            _playerMoney -= mask._maskCost;
        }
        else
        {
            onReturnMask?.Invoke(mask);
        }
    }

    private void GotKill(Mortal m)
    {
        if(m.tag == "NPC")
        {
            GiveMoney(100);
        }
    }

    private void GiveMoney(int amount)
    {
        _playerMoney += amount;
    }

    private void FixedUpdate()
    {
        _moneytxt.text = "$"+_playerMoney.ToString();
    }
}
