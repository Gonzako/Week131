using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy;
using Doozy.Engine.UI;

public class ShopViewManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameStateManager _gameStateManager;

    public delegate void ShopTransactionEvents(Mask mask);
    public ShopTransactionEvents onMaskBought;

    public delegate void ShopEvents();
    public ShopEvents onShoppingDone;
    public ShopEvents onShopOpen;
 

    [SerializeField] private List<Mask> _shopInventory;
    [SerializeField] private UIView _panel;
    

    private void OnEnable()
    {
        _gameStateManager = FindObjectOfType<GameStateManager>();
        _gameStateManager.onStateChanged += ShopHandle;
    }

    private void OnDisable()
    {
        _gameStateManager.onStateChanged -= ShopHandle;
    }

    private void ShopHandle(GameState state)
    {
        if (state.GetType() != typeof(ShopState))
        {
            CloseShop();
        }
    }

    public void Buy(Mask mask)
    {
        onMaskBought?.Invoke(mask);
    }

    public void OpenShop()
    {
        onShopOpen?.Invoke();
        _panel.Show();
        
    }

    public void CloseShop()
    {
        _panel.Hide();
    }
}

public struct Mask
{
    Sprite _maskSprite;
    int _maskCost;
}
