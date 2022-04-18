using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    public static Health ins;
    public float PlayerHp;
    public float CurrentHp;
    public Image MaxHp;
    public Image Hp; //血量
    public Image HpRing;//心臟線條
  
    public float fadeSpeed = 1f; //透明度變化速率
    public float fade;
    public float fadee;
    public bool FadeIn; //漸深
    public bool CheckHp;
    public bool Hure; //扣血
    public bool FadeOut; //漸淡
    public GameObject PosCamera;
    //public GameObject CameraMoving;
    public Image MiniMap;
    public Image MiniMapMask;
    public Image Quasi_Heart;
    public GameObject HeartEffect;
    public Animator HeartEffectAni;//心臟特效(放最大的那顆)
    public Animator HeartAni;//實心的心臟
    public Animator HeartRingAni;//心臟線條

    public Animation Gameover;
    public bool condition;
    private void Awake()
    {
        ins = this;
        CurrentHp = PlayerHp;
    }

    public void Start()
    {
        fade = Hp.GetComponent<Image>().color.a;
        fadee = HpRing.GetComponent<Image>().color.a;
        condition = true;
    }

    // Update is called once per frame
    void Update()
    {
        MaxHp.GetComponent<Image>().fillAmount = CurrentHp / PlayerHp;

        if (Hure==true)
        {
            if (Hp.GetComponent<Image>().fillAmount > MaxHp.GetComponent<Image>().fillAmount)
            {
                Hp.fillAmount -= 0.005f;
            }
            else
            {
                Hp.fillAmount = MaxHp.fillAmount;
            }
        }
        
        if (FadeIn==true) //漸亮心臟
        {
            Hp.color = Color.Lerp(Hp.color, Color.white, Time.deltaTime * fadeSpeed * 0.5f);
            HpRing.color = Color.Lerp(HpRing.color, Color.white, Time.deltaTime * fadeSpeed * 0.5f);
            NavMesh_Component.ins.agent.speed = 0;
            if (NavMesh_Component.ins.Level02==true)
            {
                enemy_ai2.ins.agent.speed = 0;
            }
            if (NavMesh_Component.ins.Level03 == true)
            {
                enemy_ai3.ins.agent.speed = 0;
            }
            
            Ray_Pick.ins.WoodCheck = false;
            Ray_Pick.ins.GodDoorCheck = false;
            HeartEffect.SetActive(true);
            HeartEffectAni.enabled = true;
            HeartAni.enabled = true;
            HeartRingAni.enabled = true;
            FadeOut = false;
            if (Hp.color.a>0.9f)
            {
                fade = 1;
                fadee = 1;
                Hure = true;
                CheckHp = true;
            }

            MouseLook.ins.MouseMoving = false;
            PlayerMovement.ins.speed = 0;
            MiniMap.color = Color.clear;
            MiniMapMask.color = Color.clear;
            Quasi_Heart.color = Color.clear;
        }

        if (CheckHp)
        {
            if (Hp.fillAmount == MaxHp.fillAmount)
            {
                MouseLook.ins.MouseMoving = true;
                FadeIn = false;
                Hp.color = Color.Lerp(Hp.color, Color.clear, Time.deltaTime * fadeSpeed * 0.5f);
                HpRing.color = Color.Lerp(HpRing.color, Color.clear, Time.deltaTime * fadeSpeed * 0.5f);
                StartCoroutine("HealthLose");
            }
        }

        if (FadeOut==true)
        {
            if (Hp.color.a <= 0.01f)//漸暗心臟
            {
                Debug.Log("有");
                FadeOut = false;
                Hp.color = Color.clear;
                HpRing.color = Color.clear;
                Hure = false;
                CheckHp = false;
                PosCamera.SetActive(false);
                MiniMap.color = Color.white;
                MiniMapMask.color = Color.white;
                Quasi_Heart.color = Color.white;
                PlayerMovement.ins.speed = 5;
                NavMesh_Component.ins.agent.speed = 4;
                if (NavMesh_Component.ins.Level02 == true)
                {
                    enemy_ai2.ins.agent.speed = 4;
                }
                if (NavMesh_Component.ins.Level03 == true)
                {
                    enemy_ai3.ins.agent.speed = 4;
                }

                MusicManager.ins.Heart_player.clip = MusicManager.ins.Heart_clip[0];
                MusicManager.ins.Heart_player.Pause();
                Ray_Pick.ins.WoodCheck = true;
                Ray_Pick.ins.GodDoorCheck = true;
                HeartEffect.SetActive(false);
                HeartEffectAni.enabled = false;
                HeartAni.enabled = false;
                HeartRingAni.enabled = false;
            }
        }

        if (Hp.fillAmount <= 0.01f && condition) //GameOver
        {
            Debug.Log("gameover");
            FadeOut = false;
            CheckHp = false;
            Ray_Pick.ins.WoodCheck = false;
            MouseLook.ins.MouseMoving = false;
            PlayerMovement.ins.speed = 0;
            NavMesh_Component.ins.agent.speed = 0;
            if (NavMesh_Component.ins.Level02 == true)
            {
                enemy_ai2.ins.agent.speed = 0;
            }
            if (NavMesh_Component.ins.Level03 == true)
            {
                enemy_ai3.ins.agent.speed = 0;
            }
            MusicManager.ins.BGM_player.Pause();
            MusicManager.ins.Monster_player.Pause();
            MusicManager.ins.Monsterr_player.Pause();
            MusicManager.ins.Monsterrr_player.Pause();
            Invoke("GG", 3F);
            Invoke("GGG", 6F);
            condition = false;
        }
    }


    public void GG()
    {
        Debug.Log("gg");
        Gameover.Play();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        MiniMap.color = Color.clear;
        MiniMapMask.color = Color.clear;
        Quasi_Heart.color = Color.clear;
    }

    public void GGG()
    {
        Time.timeScale = 0;
    }
    IEnumerator HealthLose()
    {
        yield return new WaitForSeconds(1);
        FadeOut = true;
    }
}
