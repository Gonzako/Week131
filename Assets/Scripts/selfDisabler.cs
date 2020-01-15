using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDisabler : MonoBehaviour
{

    [SerializeField] private float _destructionTime;
    float timer;
    private Animator _anim;

    private void OnEnable()
    {
        _anim = GetComponent<Animator>();
        timer = _destructionTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer  < 0)
        {
            _anim.SetTrigger("impact");
        }
        timer -= Time.deltaTime;
    }
}
