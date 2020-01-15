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

    [SerializeField] private GameObject _emptyPanel;

    [SerializeField] private GameObject _listParent;
    [SerializeField] ItemInformation[] items;

    private GameObject _chosengb;
    private ItemShopMask _chosenmask;

    

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
    private void FixedUpdate()
    {
        if (_chosengb != null)
        {
            _emptyPanel.SetActive(false);
            _name.text = _chosenmask._name;
            _cost.text = _chosenmask._maskCost.ToString();
            _description.text = _chosenmask._description;
            _sprite = _chosenmask._spriteImage;
        }
        else
        {
            _emptyPanel.SetActive(true);
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
        if (_chosengb == null)
        {
            ob.GetComponent<Image>().color = Color.red;
            _chosengb = ob;
            _chosenmask = mask;
        }
        else
        {
            ob.GetComponent<Image>().color = Color.red;
            _chosengb.GetComponent<Image>().color = Color.white;
            _chosengb = ob;
            _chosenmask = mask;
        }
        
    }
}
