using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursorTexture;
    public Texture2D shopTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void OnEnable()
    {
        ShopViewManager.onShopOpen += EnableShopCursor;
        ShopViewManager.onShopClose += DisableShopCursor;
    }


    private void OnDisable()
    {
        ShopViewManager.onShopOpen -= EnableShopCursor;
        ShopViewManager.onShopClose -= DisableShopCursor;
    }

    private void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    private void EnableShopCursor(List<ItemShopMask> inventory)
    {
        Cursor.SetCursor(shopTexture, hotSpot, cursorMode);
    }

    private void DisableShopCursor(List<ItemShopMask> inventory)
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
}
