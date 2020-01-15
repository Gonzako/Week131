using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GonzakoUtils.DataStructures;

public class ItemListManager : MonoBehaviour
{
    public GameObject _defaultItemData;
    Pool<GameObject> _itemPool;
    ShopViewManager _shopmanager;
    Transform _trans;
    

    public delegate void ItemListEvents();
    public static ItemListEvents onAllItemsLoaded;
    private void Awake()
    {
        _itemPool = new Pool<GameObject>(4, _defaultItemData, transform);
    }
    private void OnEnable()
    {
        _trans = GetComponent<Transform>();
        ShopViewManager.onShopOpen += InstantiateShopInventory;
        ItemInformation.onItemBuy += UpdateList;
    }

    private void OnDisable()
    {
        ShopViewManager.onShopOpen -= InstantiateShopInventory;
        ItemInformation.onItemBuy = UpdateList;
    }

    private void InstantiateShopInventory(List<ItemShopMask>inventory)
    {
        CleanList();

        Debug.Log("test" + inventory.Count);
        foreach(ItemShopMask m in inventory)
        {
            Debug.Log("wtf");
            GameObject on = _itemPool.getNextObj();
            Debug.Log(on.name);
            //on.transform.SetParent(_trans);
            on.transform.localScale = new Vector3(1F, 1F, 1F);
            on.SetActive(true);
            on.GetComponent<ItemInformation>().SetData(m);
        }
        onAllItemsLoaded?.Invoke();
    }

    private void UpdateList(ItemShopMask mask, GameObject ob)
    {
        Debug.Log("ENPOOL" + mask._name);
        ob.SetActive(false);
        _itemPool.enPool(ob);
    }

    private void CleanList()
    {
        foreach (ItemInformation item in GetComponentsInChildren<ItemInformation>())
        {
            _itemPool.enPool(item.gameObject);
        }
    }
}
