using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemListManager : MonoBehaviour
{

    ShopViewManager _shopmanager;
    private void OnEnable()
    {
        _shopmanager = FindObjectOfType<ShopViewManager>();
        _shopmanager.onShopOpen += InstantiateShopInventory;
    }

    private void InstantiateShopInventory(List<ItemShopMask>inventory)
    {
        if(inventory.Count > 0)
        foreach(ItemShopMask m in inventory)
        {
            GameObject on = ShopItemPooler._instance.GetPooledObject();
            on.SetActive(true);
            on.GetComponent<ItemInformation>().SetData(m);
        }
    }
}
