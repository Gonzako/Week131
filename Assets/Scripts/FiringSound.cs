using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringSound : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        
    }


    private void OnEnable()
    {
        audioSource.Play();  
    }
}
