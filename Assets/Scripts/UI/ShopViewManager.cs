﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy;
using Doozy.Engine.UI;
using UnityEngine.UI;

public class ShopViewManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameStateManager _gameStateManager;

    public delegate void ShopTransactionEvents(ItemShopMask mask);
    public ShopTransactionEvents onMaskBought;

    public delegate void ShopEvents(List<ItemShopMask> inventory);
    public ShopEvents onShoppingDone;
    public static ShopEvents onShopOpen;
    public static ShopEvents onShopClose;
    public static ShopEvents onShopUpdate;

    private const float _timeToWait = 2f;
    private float _timerThatWaits = 0;
    

    [SerializeField] private List<ItemShopMask> _shopInventory;
    [SerializeField] private UIView _panel;

    private void OnEnable()
    {
        _gameStateManager = FindObjectOfType<GameStateManager>();

        ShopOpener.onAnyOpenCommand += OpenShop;
        _gameStateManager.onStateChanged += ShopHandle;

        ItemInformation.onItemBuy += Transaction;
        ShopInteractable.onAnyOpenCommand += OpenShop;
        PlayerMoneyManager.onReturnMask += AddIntoInventory;
    }

    private void OnDisable()
    {
        _gameStateManager.onStateChanged -= ShopHandle;
        ShopInteractable.onAnyOpenCommand -= OpenShop;
        PlayerMoneyManager.onReturnMask -= AddIntoInventory;
    }


    private void ShopHandle(GameState state)
    {
        if (state.GetType() != typeof(ShopState))
        {
            //CloseShop();
        }
    }

    public void Transaction(ItemShopMask mask, GameObject ob)
    {
        _shopInventory.Remove(mask);
        onShopUpdate?.Invoke(_shopInventory);
    }

    public void OpenShop()
    {
        if (_timerThatWaits < Time.time)
        {
            Debug.Log("OpenShop called");
            if (_panel.IsHidden)
            {
                _panel.Show();
                onShopOpen?.Invoke(_shopInventory);
                Debug.Log("open shop");
            }
            else
            {
                _panel.Hide();
                onShopClose?.Invoke(_shopInventory);
              
                Debug.Log("closed shop");
            }
            _timerThatWaits = Time.time + _timeToWait;
        }
        
    }

    private void AddIntoInventory(ItemShopMask mask)
    {
        _shopInventory.Add(mask);
    }
}

[System.Serializable]
public struct ItemShopMask
{
    public ItemShopMask(string name, int cost, string desc, Sprite img, BasicScriptableMask power)
    {
        _name = name;
        _maskCost = cost;
        _description = desc;
        _spriteImage = img;
        _power = power;
    }

    public string _name;
    public int _maskCost;
    public string _description;
    public Sprite _spriteImage;
    public BasicScriptableMask _power;
}
