using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class PlayerHurt : MonoBehaviour
{
    public GameObject player;
    
    public VideoPlayer Monster;
    public Camera MonsterCam;
    public Image MiniMap;
    public Image MiniMapMask;
    public Image Quasi_Heart;
    public GameObject PosCamera;
    public GameObject RayPick;
    public GameObject BarRing;
    public GameObject DeathCamera;
    private bool Reset;
    bool Hurt;//¨ü¶Ë
    public int count;
    private void Start()
    {
        Reset = false;
        count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Monster")
        {
            count++;
            Hurt = true;
            MiniMap.color = Color.clear;
            MiniMapMask.color = Color.clear;
            Quasi_Heart.color = Color.clear;
        }

        if (count==0)
        {
            Hurt = false;
        }

        if (Hurt==true)
        {
            if (count <= 2)//¨ü¶Ë
            {
                MonsterCam.cullingMask = (1 << 14);
                Monster.enabled = true;
                Invoke("restart", 4.5f);
                Reset = true;
                MouseLook.ins.MouseMoving = false;
                PlayerMovement.ins.speed = 0;
                RayPick.GetComponent<Ray_Pick>().enabled = false;
                BarRing.SetActive(false);
            }

            if (count >= 3)//¦º¤`
            {
                MouseLook.ins.MouseMoving = false;
                PlayerMovement.ins.speed = 0;
                DeathCamera.SetActive(true);
                Reset = true;
                BarRing.SetActive(false);
                Monster.enabled = false;
                Invoke("restart", 4.5f);
                Invoke("ClosDeathCamera", 4f);
            }
        }
    }
    private void restart()
    {
        if (Reset)
        {
            Health.ins.CurrentHp -= 33.3f;
            Health.ins.FadeIn = true;
            PosCamera.SetActive(true);
            MusicManager.ins.Heart_player.clip = MusicManager.ins.Heart_clip[0];
            MusicManager.ins.Heart_player.Play();
        }
        Reset = false;
        Hurt = false;
        RayPick.GetComponent<Ray_Pick>().enabled = true;
        /*MiniMap = Color.white;
        MiniMapMask = Color.white;*/
        Monster.GetComponent<Camera>().cullingMask |= (1 << 8) + (1 << 7) + (1 << 5) + (1 << 4) + (1 << 3) + (1 << 2) + (1 << 9) + (1 << 11) + (1 << 12) + (1 << 13) + (1 << 0) + (1 << 1);
        Monster.enabled = false;
    }

    public void ClosDeathCamera()
    {
        DeathCamera.SetActive(false);
    }
}
