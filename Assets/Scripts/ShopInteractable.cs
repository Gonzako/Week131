using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInteractable : MonoBehaviour
{
   [SerializeField] private bool _CanOpen;

    public delegate void ShopOpenerEvents();
    public static ShopOpenerEvents onAnyOpenCommand;
  

   [SerializeField] private Text _shopInteractelement;
    private Camera _cam;

    private void OnDisable()
    {
        _shopInteractelement.text = "";
    }


    private void Start()
    {
        _cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if (_CanOpen)
        {
            _shopInteractelement.text = "[E] Open Shop";
            _shopInteractelement.transform.position = transform.position + transform.up;
            if (Input.GetKeyDown(KeyCode.E))
            {
                onAnyOpenCommand?.Invoke();
            }
        }
        else
        {
            _shopInteractelement.text = "";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _CanOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _CanOpen = false;
        }
    }
}
