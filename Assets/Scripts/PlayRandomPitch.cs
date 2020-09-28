using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomPitch : MonoBehaviour
{
    public AudioClip myClip;
    public float lowerRange;
    public float upperRange;
    

    //plays a sound at a random pitch
    void Start()
    {
        AudioSource myAudio = gameObject.AddComponent<AudioSource>() as AudioSource;
        myAudio = GetComponent<AudioSource>();
        myAudio.clip = myClip;
        myAudio.pitch = Random.Range(lowerRange, upperRange);
        myAudio.Play();
    }
}
