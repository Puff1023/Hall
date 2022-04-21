using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerPickUp : MonoBehaviour
{
    public static PlayerPickUp ins;
    public Camera CameraSize;//小地圖視野範圍
    public int count; //油燈數量
    public Transform[] Ruler;
    /*public GameObject Rule1;
    public GameObject Rule2;
    public GameObject Rule3;*/
    public NavMeshAgent Monster1Nav;
    public Image Quasi_Heart;
    public Image MiniMap;
    public float Speed;
    public bool Rule11;
    public bool OpQte;
    public Transform CmCamera;
    public Transform PlayerOpenQtPos;
    public Transform Monster01DoorPos;
    public CharacterController PlayerController;
    public Vector3 NewMonster1NavPos;
    public Vector3 newRule1Pos;
    public Vector3 newRule2Pos;
    public Vector3 newRule3Pos;
    public Vector3 originalRulePos;
    public Vector3 originalRu2ePos;
    public Vector3 originalRu3ePos;

    private void Awake()
    {
        ins = this;
    }
    private void Update()
    {
        if (count >= 1)
        {
            CameraSize.orthographicSize = 6;
        }

        if (count >= 2)
        {
            CameraSize.orthographicSize = 7;
        }

        if (count >= 3)
        {
            CameraSize.orthographicSize = 8;
        }

        if (count >= 4)
        {
            CameraSize.orthographicSize = 9;
        }
        if (count >= 5)
        {
            CameraSize.orthographicSize = 10;
        }

        if (Rule11==true)
        {
            Ruler[0].position = Vector3.Lerp(Ruler[0].position, newRule1Pos, 0.1f);
            Ruler[1].position = Vector3.Lerp(Ruler[1].position, newRule2Pos, 0.1f);
            Ruler[2].position = Vector3.Lerp(Ruler[2].position, newRule3Pos, 0.1f);
            Ruler[0].rotation = Quaternion.Euler(0, 90, 270);
            Ruler[1].rotation = Quaternion.Euler(0, 0, 270);
            Ruler[2].rotation = Quaternion.Euler(0, -90, 270);
            PlayerMovement.ins.speed = 0;
            LookatCamera.ins.CamLookAt = true;
            Invoke("RulerBake", 5);
        }

        if (OpQte)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Quasi_Heart.color = Color.clear;
            CmCamera.transform.rotation = Quaternion.Euler(30, 0, 0);
            Monster1Nav.Warp(NewMonster1NavPos);
            transform.position = Vector3.Lerp(transform.position, PlayerOpenQtPos.position, 0.1f);
            //transform.position = PlayerOpenQtPos.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(30, 0, 0), 0.05f);
            PlayerMovement.ins.speed = 0;
            PlayerController.enabled = false;
            MouseLook.ins.MouseMoving = false;
            NavMesh_Component.ins.agent.speed = 0;
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp")//油燈
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            MusicManager.ins.oillight_player.clip = MusicManager.ins.oillight_clip[0];
            MusicManager.ins.oillight_player.Play();
        }

        if (other.tag=="Rule1")//相框
        {
            Rule11 = true;
        }

        if (other.tag == "OpQte")
        {
            Debug.Log("碰到");
            OpQte = true;
            MusicManager.ins.KnockDoor_player.clip = MusicManager.ins.KnockDoor_clip[0];
            MusicManager.ins.KnockDoor_player.Play();//鬼敲門

        }

        if (other.tag == "Shoses")//debuff開(雨鞋)
        {
            other.gameObject.SetActive(false);
            PlayerMovement.ins.speed -= 3;
            MusicManager.ins.RainShoses_player.clip = MusicManager.ins.RainShoses_clip[0];
            MusicManager.ins.RainShoses_player.Play();
            MusicManager.ins.BGM_player.clip = MusicManager.ins.BGM_clip[0];
            MusicManager.ins.BGM_player.Pause();
            StartCoroutine("CloSlow");
        }
        if (other.tag=="PlayerOriginal")
        {
            Health.ins.MouseCheck = true;
        }
    }

    public void RulerBake()
    {
        Rule11 = false;
        Ruler[0].position = Vector3.Lerp(Ruler[0].position, originalRulePos, 0.1f);
        Ruler[1].position = Vector3.Lerp(Ruler[1].position, originalRu2ePos, 0.1f);
        Ruler[2].position = Vector3.Lerp(Ruler[2].position, originalRu3ePos, 0.1f);
        //Rule1.transform.position = Vector3.Lerp(Rule1.transform.position, originalRulePos, 0.1f);
        Ruler[0].rotation = Quaternion.Euler(0, 90, 270);
        Ruler[1].rotation = Quaternion.Euler(0, 0, 270);
        Ruler[2].rotation = Quaternion.Euler(0, -90, 270);
        PlayerMovement.ins.speed = 5;
        LookatCamera.ins.CamLookAt = false;
    }

    IEnumerator CloSlow()//debuff關
    {
        yield return new WaitForSeconds(5f);
        MusicManager.ins.RainShoses_player.clip = MusicManager.ins.RainShoses_clip[0];
        MusicManager.ins.RainShoses_player.Pause();
        MusicManager.ins.BGM_player.clip = MusicManager.ins.BGM_clip[0];
        MusicManager.ins.BGM_player.Play();
        PlayerMovement.ins.speed += 3;
    }
}
