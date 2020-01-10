using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopViewManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameStateManager _gameStateManager;

    public delegate void ShopTransactionEvents(Mask mask);
    public ShopTransactionEvents onMaskBought;

    public delegate void ShopEvents();
    public ShopEvents onShoppingDone;
 

    [SerializeField] private List<Mask> _shopInventory;
    [SerializeField] private GameObject _panel;

    private void OnEnable()
    {
        _gameStateManager = FindObjectOfType<GameStateManager>();
        _gameStateManager.onStateChanged += ShowView;
    }

    private void OnDisable()
    {
        _gameStateManager.onStateChanged -= ShowView;
    }

    private void ShowView(GameState state)
    {
        if (state.GetType() == typeof(ShopState))
        {
           // _panel.SetActive(true);
        }
    }

    public void Buy(Mask mask)
    {
        onMaskBought?.Invoke(mask);
    }

    public void Ready()
    {
        _panel.SetActive(false);
        onShoppingDone?.Invoke();
    }
}

public struct Mask
{
    Sprite _maskSprite;
    int _maskCost;
}
