using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOpener : MonoBehaviour
{
    public delegate void ShopOpenerEvents();
    public static ShopOpenerEvents onAnyOpenCommand;



    private void Awake()
    {
        //onAnyOpenCommand = null;
    }

    private void Start()
    {
        Debug.Log(this.GetType().ToString());
  
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("jumpPressed");
            onAnyOpenCommand?.Invoke();
        }
    }
}
