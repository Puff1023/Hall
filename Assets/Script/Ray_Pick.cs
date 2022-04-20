using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ray_Pick : MonoBehaviour
{
    public static Ray_Pick ins;

    Ray ray;//射線的小名叫ray
    float raylength = 3f;//射線射出去的最大長度

    RaycastHit hit;//被射線打到的物件的小名叫hit

    public GameObject BarRing;
    public Outline GodDoor;
    public Outline Elva_in_Bnt;
    public Outline Elva_out_Bnt;
    public Animator OutIronDoor;
    public int count=0;
    public Image Bar;
    public Image MouseBar;
    public GameObject MouseMoveBar;
    public GameObject player;
    public GameObject LookCheck;
    public GameObject MouseLookScript;
    public Text MouseSetting;
    public Animator WoodTrigger;
    public bool WoodCheck;
    public bool GodDoorCheck;
    public bool MouseBarPlus;//固定視角Bar條

    public bool condition;
    public bool condition2;
    public GameObject BGMSlider;
    public GameObject Elev_button_delete;
    public Animation elevator_animation;
    public bool ElvaOp;
    private void Awake()
    {
        ins = this;
    }

    private void Start()
    {
        condition = true;
        condition2 = false;
    }


    public void Con1()
    {
        condition = true;
    }

    public void Con2()
    {
        condition2 = true;
    }

    void FixedUpdate()
    {
        if (MouseBarPlus == true)//還要修
        {
            MouseBar.fillAmount += 0.005f;

            if (MouseBar.fillAmount >= 0.99f)
            {
                MouseBar.fillAmount = 1;
                MouseLookScript.GetComponent<MouseLook>().enabled = true;
                MouseLook.ins.MouseMovingChang = false;
                PlayerMovement.ins.speed = 5;
                MouseMoveBar.SetActive(false);
                MouseSetting.color = Color.white;
                Invoke("ppp", 3);
            }
        }

        //告訴射線射出去是由攝影機正中心點射出
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        //(射線,out 被打到的物件,射線長度) out hit=把射線打到的物件帶(out)給hit
        if (Physics.Raycast(ray, out hit, raylength))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.yellow);
            hit.transform.SendMessage("HitByRaycast", gameObject, SendMessageOptions.DontRequireReceiver);
            if (GodDoorCheck==true)
            {
                if (hit.transform.tag == "GodDoor") //開神明廳的門
                {
                    GodDoor.OutlineWidth = 5;

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        count %= 2;
                        MusicManager.ins.DoorEffect_player.clip = MusicManager.ins.DoorEffect_clip[0];
                        MusicManager.ins.DoorEffect_player.Play();

                        if (count <= 0)//關門
                        {
                            OutIronDoor.SetBool("CloDoor", true);
                            Debug.Log("關門");
                            count = 3;
                        }
                        else
                        {
                            OutIronDoor.SetBool("CloDoor", false);
                        }
                        if (count == 1)//開門
                        {
                            OutIronDoor.SetBool("OpenDoor", true);
                            Debug.Log("開門");
                            count++;
                        }
                        else
                        {
                            OutIronDoor.SetBool("OpenDoor", false);
                        }
                    }

                }
                else
                {
                    GodDoor.OutlineWidth = 0;
                }
            }

            if (ElvaOp)
            {
                if (hit.transform.tag == "elev_in_button" && condition2)
                {
                    Elva_in_Bnt.OutlineWidth = 5;
                    //{
                        if (Input.GetKeyDown(KeyCode.Mouse0))
                        {
                            GameObject.Find("Continue_scene").SendMessage("UseElevator");
                            MusicManager.ins.ElevatorRunning_player.clip = MusicManager.ins.ElevatorRunning_clip[0];
                            MusicManager.ins.ElevatorRunning_player.Play();
                            Elev_button_delete.GetComponent<BoxCollider>().enabled = false;
                        }
                    //}
                }
                else
                {
                    Elva_in_Bnt.OutlineWidth = 0;
                }

                if (hit.transform.tag == "elev_out_button")
                {
                    Elva_out_Bnt.OutlineWidth = 5;
                    if (condition)
                    {
                        if (Input.GetKeyDown(KeyCode.Mouse0))
                        {
                            elevator_animation.Play();
                            MusicManager.ins.ElevatorOpen_player.clip = MusicManager.ins.ElevatorOpen_clip[0];
                            MusicManager.ins.ElevatorOpen_player.Play();
                            condition = false;
                            Invoke("Con1", 6.5f);
                            Invoke("Con2", 6.5f);
                            BGMSlider.GetComponent<Slider>().value = 0.5F;

                        }
                    }
                }
                else
                {
                    Elva_out_Bnt.OutlineWidth = 0;
                }

            }

            if (WoodCheck==true)
            {
                if (hit.transform.tag == "Wood")
                {
                    Bar.fillAmount -= 0.5f * Time.deltaTime;
                    BarRing.SetActive(true);
                    PlayerMovement.ins.speed = 2;
                    hit.transform.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Bar.fillAmount += 0.3f;
                        MusicManager.ins.WoodKnock_player.clip = MusicManager.ins.Wood_clip[0];
                        MusicManager.ins.WoodKnock_player.Play();
                        if (Bar.fillAmount >= 1)
                        {
                            PlayerMovement.ins.speed += 3;
                            WoodTrigger.SetBool("WoodTrigger", true);
                            hit.transform.gameObject.GetComponent<Animator>().enabled = true;
                            hit.transform.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                            hit.transform.tag = "WoodTrigger";
                            BarRing.SetActive(false);
                            MusicManager.ins.WoodBroken_player.clip = MusicManager.ins.Wood_clip[1];
                            MusicManager.ins.WoodBroken_player.Play();
                            MusicManager.ins.WoodKnock_player.Pause();
                        }
                    }
                }
                else
                {
                    BarRing.SetActive(false);
                    Bar.fillAmount = 0;
                }
            }
            else
            {
                BarRing.SetActive(false);
            }

            if (hit.transform.tag=="MouseMoveCheck")//固定視角用
            {
                MouseLookScript.GetComponent<MouseLook>().enabled = false;
                MouseBarPlus = true;
                PlayerMovement.ins.speed = 0;
                Debug.Log("1254845");
            }
        }
    }

    public void ppp()
    {
        LookCheck.SetActive(false);
        MouseBarPlus = false;
        MouseSetting.color = Color.clear;
        MouseBar.fillAmount = 0;
        PlayerMovement.ins.speed = 5;
        MouseLookScript.GetComponent<MouseLook>().enabled = true;
    }
}

