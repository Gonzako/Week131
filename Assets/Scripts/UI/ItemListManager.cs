using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GonzakoUtils.DataStructures;

public class ItemListManager : MonoBehaviour
{
    public GameObject _defaultItemData;
    //Pool<GameObject> _itemPool;
    ShopViewManager _shopmanager;
    Transform _trans;

    public delegate void ItemListEvents();
    

    private void Start()
    {
        //_itemPool = new Pool<GameObject>(5, _defaultItemData);
        //_trans = GetComponent<Transform>();
    }
    private void OnEnable()
    {
        _trans = GetComponent<Transform>();
        ShopViewManager.onShopOpen += InstantiateShopInventory;
    }

    private void OnDisable()
    {
        ShopViewManager.onShopOpen -= InstantiateShopInventory;
    }

    private void InstantiateShopInventory(List<ItemShopMask>inventory)
    {
        Debug.Log("test" + inventory.Count);
        foreach(ItemShopMask m in inventory)
        {
            Debug.Log("wtf");
            GameObject on = ShopItemPooler._pooler.getpooledObject();
            Debug.Log(on.name);
            on.transform.SetParent(_trans);
            on.transform.localScale = new Vector3(1F, 1F, 1F);
            on.GetComponent<ItemInformation>().SetData(m);
        }
    }
}
