using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GonzakoUtils.DataStructures;

public class ItemListManager : MonoBehaviour
{
    public GameObject _defaultItemData;
    Pool<GameObject> _itemPool;
    ShopViewManager _shopmanager;
    private void OnEnable()
    {
        _shopmanager = FindObjectOfType<ShopViewManager>();
        _shopmanager.onShopOpen += InstantiateShopInventory;
        _itemPool = new Pool<GameObject>(5, _defaultItemData);
    }

    private void OnDisable()
    {
        _shopmanager.onShopOpen -= InstantiateShopInventory;
    }

    private void InstantiateShopInventory(List<ItemShopMask>inventory)
    {
        if(inventory.Count > 0)
        foreach(ItemShopMask m in inventory)
        {
            GameObject on = _itemPool.getNextObj();
            on.SetActive(true);
            on.GetComponent<ItemInformation>().SetData(m);
        }
    }
}
