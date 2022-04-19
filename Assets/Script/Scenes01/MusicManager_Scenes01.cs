using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager_Scenes01 : MonoBehaviour
{
    public static MusicManager_Scenes01 ins;

    [Header("��z�C��")]
    public AudioSource BGM_player;//BGM
    public AudioSource VillaDoor_player;//�s�����}���n
    public AudioSource Thunder_player;//�p�n
    public AudioSource MonsterLose_player;//�Ǫ�����
    public AudioSource ChangScenes_player;//���
    public AudioSource FootStep_player;//�}�B�n

    [Tooltip("���ɰ}�C")]
    public AudioClip[] BGM_clip;
    public AudioClip[] VillaDoor_clip;
    public AudioClip[] Thunder_clip;
    public AudioClip[] MonsterLose_clip;
    public AudioClip[] ChangScenes_clip;
    public AudioClip[] FootStep_clip;

    bool FootStepIsPlaying = false;

    private void Awake()
    {
        ins = this;
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
