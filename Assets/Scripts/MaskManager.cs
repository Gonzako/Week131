using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskManager : MonoBehaviour
{

    [SerializeField] private BasicScriptableMask _currentMask;

    private Camera _cam;
    private Vector2 mouseDirVector;

    private void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _currentMask.Fire(transform, getAngleTowardsMouse() + 180);
        }        
    }

    private float getAngleTowardsMouse()
    {
        mouseDirVector = Input.mousePosition - _cam.WorldToScreenPoint(transform.position);
        return Mathf.Atan2(mouseDirVector.y, mouseDirVector.x) * Mathf.Rad2Deg;

    }
}
