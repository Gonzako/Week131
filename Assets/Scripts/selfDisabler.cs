using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDisabler : MonoBehaviour
{

    [SerializeField] private float _destructionTime;
    float timer;
    private void OnEnable()
    {
        timer = _destructionTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer  < 0)
        {
            this.gameObject.SetActive(false);
        }
        timer -= Time.deltaTime;
    }
}
