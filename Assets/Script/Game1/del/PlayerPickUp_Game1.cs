using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickUp_Game1 : MonoBehaviour
{
    public static PlayerPickUp_Game1 ins;
    public Camera CameraSize;//�p�a�ϵ����d��
    public int count; //�o�O�ƶq
    public GameObject Rule1;
    public GameObject Rule2;
    public GameObject Rule3;
    public Transform Monster1;
    public Image Quasi_Heart;
    public Image MiniMap;
    public float Speed;
    public bool Rule11;
    public bool OpQte;
    public Transform CmCamera;
    Vector3 newRule1Pos = new Vector3(-45f, 2.16f, -38.7f);
    Vector3 originalRulePos = new Vector3(-45.59f, 2.16f, -38.7f);
    Vector3 newPlayerPos = new Vector3(17.8f, 0.8f, 70.5f);
    Vector3 newMonster1Pos = new Vector3(29.4f, 0.1f, 66.6f);
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

        if (Rule11==true)//�ݳW�h
        {
            Rule1.transform.position = Vector3.Lerp(Rule1.transform.position, newRule1Pos, 0.1f);
            PlayerMovement.ins.speed = 0;
            LookatCamera.ins.CamLookAt = true;
            Invoke("qqq", 3);
        }

        if (OpQte)
        {
            PlayerMovement.ins.speed = 0;
            MouseLook.ins.MouseMoving = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Quasi_Heart.color = Color.clear;
            CmCamera.transform.rotation = Quaternion.Euler(30, 0, 0);
            Monster1.position = newMonster1Pos;
            transform.position = Vector3.Lerp(transform.position, newPlayerPos, 0.1f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(30, 0, 0), 0.05f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp")//�o�O
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            MusicManager.ins.oillight_player.clip = MusicManager.ins.oillight_clip[0];
            MusicManager.ins.oillight_player.Play();
        }

        if (other.tag=="Rule1")//�ۮ�
        {
            Rule11 = true;
        }

        if (other.tag == "OpQte")
        {
            OpQte = true;
            
            NavMesh_Component.ins.agent.speed = 0;
            MusicManager.ins.KnockDoor_player.clip = MusicManager.ins.KnockDoor_clip[0];
            MusicManager.ins.KnockDoor_player.Play();//���V��
        }

        if (other.tag == "Shoses")//debuff�}(�B�c)
        {
            other.gameObject.SetActive(false);
            PlayerMovement.ins.speed -= 3;
            MusicManager.ins.RainShoses_player.clip = MusicManager.ins.RainShoses_clip[0];
            MusicManager.ins.RainShoses_player.Play();
            MusicManager.ins.BGM_player.clip = MusicManager.ins.BGM_clip[0];
            MusicManager.ins.BGM_player.Pause();
            StartCoroutine("CloSlow");
        }
    }

    public void qqq()
    {
        Rule11 = false;
        Rule1.transform.position = Vector3.Lerp(Rule1.transform.position, originalRulePos, 0.1f);
        Rule1.transform.rotation = Quaternion.Lerp(Rule1.transform.rotation, Quaternion.Euler(0, 90, 0), 0.05f);
        PlayerMovement.ins.speed = 5;
        LookatCamera.ins.CamLookAt = false;
    }

    IEnumerator CloSlow()//debuff��
    {
        yield return new WaitForSeconds(5f);
        MusicManager.ins.RainShoses_player.clip = MusicManager.ins.RainShoses_clip[0];
        MusicManager.ins.RainShoses_player.Pause();
        MusicManager.ins.BGM_player.clip = MusicManager.ins.BGM_clip[0];
        MusicManager.ins.BGM_player.Play();
        PlayerMovement.ins.speed += 3;
    }
}