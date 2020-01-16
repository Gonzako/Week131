using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealthCanvasManager : MonoBehaviour
{
    
    private void OnEnable()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
