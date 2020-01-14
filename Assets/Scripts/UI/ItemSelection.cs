using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelection : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private Text _cost;
    [SerializeField] private Text _description;
    [SerializeField] private Sprite _sprite;

    [SerializeField] private GameObject _listParent;
    [SerializeField] ItemInformation[] items;

    private GameObject _chosen;

    

    private void OnEnable()
    {

        ItemListManager.onAllItemsLoaded += Subsribe;
    
    }

    private void Subsribe()
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
        ItemListManager.onAllItemsLoaded -= Subsribe;
        if (items.Length > 0)
        {
            foreach (ItemInformation im in items)
            {
                im.onItemChosen -= UpdateDescription;
            }
        }

    }

    private void UpdateDescription(ItemShopMask mask, GameObject ob)
    {
        Debug.Log(mask._name);
        _name.text = mask._name;
        _cost.text = mask._maskCost.ToString();
        _description.text = mask._description;
        _sprite = mask._spriteImage;


        if (_chosen == null)
            _chosen = ob;
        else
        {
            ob.GetComponent<Image>().color = Color.red;
            _chosen.GetComponent<Image>().color = Color.white;

            _chosen = ob;
        }
    }
}
