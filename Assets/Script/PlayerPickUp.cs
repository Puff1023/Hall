using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickUp : MonoBehaviour
{
    public static PlayerPickUp ins;
    public Camera CameraSize;//小地圖視野範圍
    public int count; //油燈數量
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
    Vector3 newRule1Pos = new Vector3(7.5f, 2.16f, 7.95f);
    Vector3 originalRulePos = new Vector3(7f, 2.16f, 7.95f);
    Vector3 newPlayerPos = new Vector3(44, 1, -19.54f);
    Vector3 newMonster1Pos = new Vector3(44.6f, 0.5f, -12.7f);
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
            Rule1.transform.position = Vector3.Lerp(Rule1.transform.position, newRule1Pos, 0.1f);
            PlayerMovement.ins.speed = 0;
            //CmCamera.SetActive(false);
            LookatCamera.ins.CamLookAt = true;
            Invoke("qqq", 10);
        }

        if (OpQte)
        {
            PlayerMovement.ins.speed = 0;
            MouseLook.ins.MouseMoving = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Quasi_Heart.color = Color.clear;
            CmCamera.transform.rotation = Quaternion.Euler(20, -90, 0);
            transform.position = Vector3.Lerp(transform.position, newPlayerPos, 0.1f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(20, -90, 0), 0.05f);
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
            OpQte = true;
            Monster1.position = newMonster1Pos;
            NavMesh_Component.ins.agent.speed = 0;
            MusicManager.ins.KnockDoor_player.clip = MusicManager.ins.KnockDoor_clip[0];
            MusicManager.ins.KnockDoor_player.Play();//鬼敲門
        }

        if (other.tag == "Shoses")//debuff開(雨鞋)
        {
            other.gameObject.SetActive(false);
            PlayerMovement.ins.speed -= 4;
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
        Rule1.transform.rotation = Quaternion.Lerp(Rule1.transform.rotation, Quaternion.Euler(0, 90, 90), 0.05f);
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
        PlayerMovement.ins.speed += 4;
    }
}
