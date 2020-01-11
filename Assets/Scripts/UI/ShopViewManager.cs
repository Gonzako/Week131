using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy;
using Doozy.Engine.UI;

public class ShopViewManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameStateManager _gameStateManager;

    public delegate void ShopTransactionEvents(ItemShopMask mask);
    public ShopTransactionEvents onMaskBought;

    public delegate void ShopEvents(List<ItemShopMask> inventory);
    public ShopEvents onShoppingDone;
    public ShopEvents onShopOpen;
    public ShopEvents onShopClose;
 

    [SerializeField] private List<ItemShopMask> _shopInventory;
    [SerializeField] private UIView _panel;

    private void OnEnable()
    {
        _gameStateManager = FindObjectOfType<GameStateManager>();

        _gameStateManager.onStateChanged += ShopHandle;
        ShopOpener.onAnyOpenCommand += OpenShop;
    }

    private void OnDisable()
    {
        _gameStateManager.onStateChanged -= ShopHandle;
        ShopOpener.onAnyOpenCommand -= OpenShop;
    }


    private void ShopHandle(GameState state)
    {
        if (state.GetType() != typeof(ShopState))
        {
            //CloseShop();
        }
    }

    public void Buy(ItemShopMask mask)
    {
        onMaskBought?.Invoke(mask);
    }

    public void OpenShop()
    {
        if (_panel.IsHidden)
        {
            onShopOpen?.Invoke(_shopInventory);
            _panel.Show();
        }
        else
        {
            onShopClose?.Invoke(_shopInventory);
            _panel.Hide();
        }
        
    }
}

[System.Serializable]
public struct ItemShopMask
{
    public Mask(string name, int cost)
    {
        _name = name;
        _maskCost = cost;
    }
    public string _name;
    public int _maskCost;
}
