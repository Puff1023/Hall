using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager_F : MonoBehaviour
{
    public static MusicManager_F insF;

    [Header("³â¥z¦Cªí")]
    public AudioSource ElevatorF_player;
    public AudioSource DoorF_player;
    public AudioSource Hit_player;
    public AudioSource BGM_player;
    public AudioSource FootStep_player;

    [Tooltip("­µÀÉ°}¦C")]
    public AudioClip[] ElevatorF_clip;
    public AudioClip[] DoorF_clip;
    public AudioClip[] Hit_clip;
    public AudioClip[] BGM_clip;
    public AudioClip[] FootStep_clip;

    bool FootStepIsPlaying = false;
    // Start is called before the first frame update
    private void Awake()
    {
        insF = this;
    }

    private void Start()
    {
        FootStep_player.clip = FootStep_clip[0];
        PlayerBGM();
    }

    public void PlayerBGM()
    {
        BGM_player.clip = BGM_clip[0];
        BGM_player.Play();
    }



    public void PlayFootStep()
    {
        if (FootStepIsPlaying)
        {
            return;

        }
        FootStepIsPlaying = true;
        FootStep_player.Play();

    }

    public void StopFootStep()
    {
        if (!FootStepIsPlaying)
        {
            return;
        }
        FootStepIsPlaying = false;
        FootStep_player.Stop();
    }
}
