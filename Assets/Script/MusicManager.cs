using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public static MusicManager ins;

    [Header("喇叭列表")]
    public AudioSource BGM_player;//BGM
    public AudioSource DoorEffect_player;//鐵門開啟聲
    public AudioSource Monster_player;//怪物笑聲1
    public AudioSource Monsterr_player;//怪物笑聲2
    public AudioSource Monsterrr_player;//怪物笑聲3
    public AudioSource FootStep_player;//腳步聲
    public AudioSource ElevatorOpen_player;//電梯門開啟
    public AudioSource ElevatorRunning_player;
    public AudioSource oillight_player;//吃油燈
    public AudioSource Heart_player;//心跳聲
    public AudioSource QteTimer_player;//QTE倒數
    //以下是新的
    public AudioSource ElvaLight_player;//啟用電梯的燈
    public AudioSource RainShoses_player;//吃雨鞋
    public AudioSource Burning_player;//符咒燃燒
    public AudioSource KnockDoor_player;//鬼敲門
    public AudioSource BwolBroken_player;//碗破
    public AudioSource WoodKnock_player;//拍木板
    public AudioSource WoodBroken_player;//木板破
    public AudioSource QTE_player;//qte出現
    public AudioSource QteScesse_player;//qte成功
    public AudioSource QteFail_player;//qte失敗


    [Tooltip("音檔陣列")]
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
