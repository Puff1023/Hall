using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public static MusicManager ins;

    [Header("��z�C��")]
    public AudioSource BGM_player;//BGM
    public AudioSource DoorEffect_player;//�K���}���n
    public AudioSource Monster_player;//�Ǫ����n1
    public AudioSource Monsterr_player;//�Ǫ����n2
    public AudioSource Monsterrr_player;//�Ǫ����n3
    public AudioSource FootStep_player;//�}�B�n
    public AudioSource ElevatorOpen_player;//�q����}��
    public AudioSource ElevatorRunning_player;
    public AudioSource oillight_player;//�Y�o�O
    public AudioSource Heart_player;//�߸��n
    public AudioSource QteTimer_player;//QTE�˼�
    //�H�U�O�s��
    public AudioSource ElvaLight_player;//�ҥιq�誺�O
    public AudioSource RainShoses_player;//�Y�B�c
    public AudioSource Burning_player;//�ũG�U�N
    public AudioSource KnockDoor_player;//���V��
    public AudioSource BwolBroken_player;//�J�}
    public AudioSource WoodKnock_player;//���O
    public AudioSource WoodBroken_player;//��O�}
    public AudioSource QTE_player;//qte�X�{
    public AudioSource QteScesse_player;//qte���\
    public AudioSource QteFail_player;//qte����


    [Tooltip("���ɰ}�C")]
    public AudioClip[] BGM_clip;
    public AudioClip[] DoorEffect_clip;
    public AudioClip[] Monster_clip;
    public AudioClip[] FootStep_clip;
    public AudioClip[] ElevatorOpen_clip;
    public AudioClip[] ElevatorRunning_clip;
    public AudioClip[] oillight_clip;
    public AudioClip[] Heart_clip;
    public AudioClip[] QteTimer_clip;
    public AudioClip[] ElvaLight_clip;
    public AudioClip[] RainShoses_clip;
    public AudioClip[] Burning_clip;
    public AudioClip[] KnockDoor_clip;
    public AudioClip[] BwolBroken_clip;
    public AudioClip[] Wood_clip;
    public AudioClip[] QTE_clip;



    bool FootStepIsPlaying=false;

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
