using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelection : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private Text _cost;
    [SerializeField] private Text _description;
    [SerializeField] private Image _sprite;

    [SerializeField] private GameObject _listParent;
    [SerializeField] ItemInformation[] items;

    private void OnEnable()
    {
        items = _listParent.GetComponentsInChildren<ItemInformation>();
        if (items.Length > 0)
        {
            foreach (ItemInformation im in items)
            {
                im.onItemChosen += UpdateDescription;
            }
        }
    }

    private void Start()
    {
        items = _listParent.GetComponentsInChildren<ItemInformation>();
        if (items.Length > 0)
        {
            foreach (ItemInformation im in items)
            {
                im.onItemChosen += UpdateDescription;
            }
        }
    }

    private void OnDisable()
    {
        foreach (ItemInformation im in items)
        {
            im.onItemChosen -= UpdateDescription;
        }
    }

    private void UpdateDescription(ItemShopMask mask)
    {
        Debug.Log(mask._name);
        _name.text = mask._name;
        _cost.text = mask._maskCost.ToString();
        _description.text = mask._description;
        _sprite = mask._spriteImage;
    }
}
