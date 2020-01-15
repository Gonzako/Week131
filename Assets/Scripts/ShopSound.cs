using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        ShopInteractable.onAnyOpenCommand += Gonzako; 
    }

    private void OnDisable()
    {
        ShopInteractable.onAnyOpenCommand -= Gonzako; 
    }

    void Gonzako()
    {
        Debug.Log("Gonzako"); 
    }
}
