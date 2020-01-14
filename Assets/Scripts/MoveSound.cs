using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSound : MonoBehaviour
{ 
    movementAnimator movAnim;
    AudioSource audioSource;
    AudioSource footstepsSource;
    public AudioClip[] footsteps;
    public static int shuffle;

    //Target shuffle length. Need a non static variable to show in Unity inspector. 
    public int setShuffle;

    //Recently played sound index
    public int[] index;
    private int currentIndex = 0;

    private void handleMoveStart(Vector2 direction)
    {
        audioSource.pitch = Random.Range(0.9f, 1.1f); 
        audioSource.Play(); 
    }

    void playRun()
    {
        int soundPlaying;
        //The while loop cycles through the index checking for a previously played sound. If it finds one while loop starts again picking another random value. If not breaks from loop. 
        while (true)
        {
            soundPlaying = randomSound();
            bool foundSoundPlaying = false;
            for (int i = 0; i < shuffle; i++)
            {
                if (index[i] == soundPlaying) { foundSoundPlaying = true; }
            }
            if (!foundSoundPlaying) { break; }
        }
        index[currentIndex] = soundPlaying;
        Debug.Log(index[currentIndex]);
        currentIndex++;
        if (currentIndex == shuffle)
        {
            currentIndex = 0;
        }
        //Plays sound. Apparently this method is better as we made a variable and stored it rather than using a getter each time. 
        audioSource.clip = footsteps[soundPlaying];
        audioSource.Play();
        //Resets currentIndex when it equals shuffle number


    }

    int randomSound()
    {
        int random = Random.Range(0, footsteps.Length);
        return random; 

    }


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        footstepsSource = GetComponent<AudioSource>(); 
        shuffle = setShuffle;
        //initializing index length to the same as shuffle
        index = new int[shuffle];

        //Setting all values in index to -1 at start. Done as a placeholder for an array value we will never have. 
        for (int i = 0; i < shuffle; i++) { index[i] = -1; }
    }

    private void OnEnable()
    {
        movAnim = GetComponent<movementAnimator>();
        movAnim.onMovementStart += handleMoveStart;
    }

    private void OnDisable()
    {
        movAnim.onMovementStart -= handleMoveStart;
    }
    void FixedUpdate()
    {

    }
}
