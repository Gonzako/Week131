using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveNoFear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)Time.time % 10 == 0)
        {

            Debug.Log("Have no fear, Jon is here");  
        }
    }
}
