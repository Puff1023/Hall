using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Scenes01 : MonoBehaviour
{
    public static PlayerMovement_Scenes01 ins;
    
    //public GameObject FootStep;
    public CharacterController controller;

    public float speed;      //移動速度
    public float gravity = -9.81f; //重力
    //public float jumpHeight = 3f;  //跳的高度

    //public Transform groundCheck;
    //public float groundDistance = 0.4f;
    //public LayerMask grondMask;

    Vector3 velocity;
    //public bool isGrounded;
    private void Awake()
    {
        ins = this;
    }

    private void Start()
    {
        //Music_manager.ins.PlayerBGM();
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, grondMask);

        //if(isGrounded && velocity.y<0)
        //{
        //    velocity.y = -2f;
        //}

        float x = Input.GetAxis("Horizontal"); //水平 A、D鍵
        float z = Input.GetAxis("Vertical");  //垂直 W、S鍵

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            //MusicManager.ins.PlayFootStep();
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
           //MusicManager.ins.StopFootStep();
        }

        

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

       // if(Input.GetButtonDown("Jump")&& isGrounded) //按空白鍵會跳
       // {
       //     velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            
       // }

       //if(!isGrounded)
       // {
       //     //Music_manager.ins.StopFootStep();
       // }
       
        velocity.y += gravity * Time.deltaTime; //重力

        controller.Move(velocity *Time.deltaTime);
    }
}
