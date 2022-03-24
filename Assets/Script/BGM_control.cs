using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_control : MonoBehaviour
{
    public static BGM_control BGM_C;
    private AudioSource audioSource;

   
    private float preVolume;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
       
        preVolume = audioSource.volume;
    }
    public void VolumeChanged(float newVolume)
    {
        audioSource.volume = newVolume;
      
    }
    


}
