using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringSound : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
       // audioSource = GetComponent<AudioSource>(); 
    }

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();  
    }
}
