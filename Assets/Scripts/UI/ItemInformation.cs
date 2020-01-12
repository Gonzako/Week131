using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInformation : MonoBehaviour
{
    

    private Text _maskName;
    private Text _cost;
    private Image _maskSprite;
    private Image _thisImage;
  

    private ItemShopMask _data;

    public delegate void UI_ITEM_EVENTS(ItemShopMask mask, GameObject ob);
    public UI_ITEM_EVENTS onItemChosen;

    private void OnEnable()
    {
        SetRefrences();
    }

    private void Start()
    {
        SetRefrences();
    }

    public void SetData(ItemShopMask mask)
    {
        _maskName.text = mask._name;
        _cost.text = mask._maskCost.ToString();
        _data = mask;
        _thisImage = GetComponent<Image>();
    }

    private void SetRefrences()
    {
        Text[] col = GetComponentsInChildren<Text>();

        foreach (Text t in col)
        {
            if (t.gameObject.name == "txt_name")
            {
                _maskName = t;
            }
            if (t.gameObject.name == "txt_cost")
            {
                _cost = t;
            }
        }

        _maskSprite = GetComponentInChildren<Image>();
    }

  
    public void Test()
    {
       this.onItemChosen?.Invoke(_data, this.gameObject);
       // _thisImage.color = Color.red;

    }

   
}
