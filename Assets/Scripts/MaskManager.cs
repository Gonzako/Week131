using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskManager : MonoBehaviour
{

    [SerializeField] private BasicScriptableMask _currentMask;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _currentMask.Fire(transform.position, transform.rotation.x);
        }        
    }
}
