using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOpener : MonoBehaviour
{
    public delegate void ShopOpenerEvents();
    public static ShopOpenerEvents onAnyOpenCommand;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            onAnyOpenCommand?.Invoke();
        }
    }
}
