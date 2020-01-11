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

    private const float _timeToWait = 2f;
    private float _timerThatWaits = 0;

    [SerializeField] private List<ItemShopMask> _shopInventory;
    [SerializeField] private UIView _panel;

    private void OnEnable()
    {
        _gameStateManager = FindObjectOfType<GameStateManager>();
        ShopOpener.onAnyOpenCommand += OpenShop;
        _gameStateManager.onStateChanged += ShopHandle;
        //ShopOpener.onAnyOpenCommand += OpenShop;
    }

    private void OnDisable()
    {
        _gameStateManager.onStateChanged -= ShopHandle;
        ShopOpener.onAnyOpenCommand -= OpenShop;        ShopOpener.onAnyOpenCommand -= OpenShop;        ShopOpener.onAnyOpenCommand -= OpenShop;        ShopOpener.onAnyOpenCommand -= OpenShop;        ShopOpener.onAnyOpenCommand -= OpenShop;        ShopOpener.onAnyOpenCommand -= OpenShop;
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
        if (_timerThatWaits < Time.time)
        {
            Debug.Log("OpenShop called");
            if (_panel.IsHidden)
            {
                onShopOpen?.Invoke(_shopInventory);
                _panel.Show();
                Debug.Log("open shop");
            }
            else
            {
                onShopClose?.Invoke(_shopInventory);
                _panel.Hide();
                Debug.Log("closed shop");
            }
            _timerThatWaits = Time.time + _timeToWait;
        }
        
    }
}

[System.Serializable]
public struct ItemShopMask
{
    public ItemShopMask(string name, int cost)
    {
        _name = name;
        _maskCost = cost;
    }
    public string _name;
    public int _maskCost;
}
