using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_F : MonoBehaviour
{
    public static PlayerMovement_F ins;
    public CharacterController controller;
    public float speed;      //移動速度
    public AudioSource CeillingSound;
    public float count = 3;
    private void Awake()
    {
        ins = this;
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); //水平 A、D鍵
        float z = Input.GetAxis("Vertical");  //垂直 W、S鍵

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            MusicManager_F.insF.PlayFootStep();
            //if (Input.GetKey(KeyCode.LeftShift))
            //{
            //    speed = 8;
            //    //Music_manager.ins.Footstep_player.Pause();
            //    //Music_manager.ins.Footstep_player.clip = Music_manager.ins.Footstep_clip[1];
            //    //Music_manager.ins.Footstep_player.Play();
            //} 
            //else
            //{
            //    speed = 1;
            //    //Music_manager.ins.Footstep_player.Pause();
            //    //Music_manager.ins.Footstep_player.clip = Music_manager.ins.Footstep_clip[0];
            //    //Music_manager.ins.Footstep_player.Play();
            //}
        }
        else if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            MusicManager_F.insF.StopFootStep();
        }
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="CeilingLight")
        {
            other.gameObject.GetComponent<Animator>().enabled = true;
            CeillingSound.enabled = true;
            count %= 2;
        }
        if (count<=0)
        {
            CeillingSound.enabled = false;
            count++;
        }
        if (count==1)
        {
            CeillingSound.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CeilingLight")
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            CeillingSound.enabled = true;
            count++;
        }
    }




}
