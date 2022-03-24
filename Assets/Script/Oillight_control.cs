using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oillight_control : MonoBehaviour
{
    private AudioSource audioSource;

    private float preVolume;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 1;

        preVolume = audioSource.volume;
    }
    public void VolumeChanged(float newVolume)
    {
        audioSource.volume = newVolume;

    }
}
