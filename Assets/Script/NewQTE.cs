using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewQTE : MonoBehaviour
{
    public static NewQTE ins;
    public QtTigger Trigger;
    public GameObject Fade; //漸淡效果
    public GameObject PosCamera;
    public GameObject Player;
    public Transform CmCamera;
    public Image Point;
    public bool Fail;
    public bool Scessce ;
    public Animator GodDoor;
    public Animator Bowl;
    public GameObject GodTable;
    public Transform SpellWater;
    public Image Quasi_Heart;
    public float PointCount;
    public RandomPoint randomPoint;
    public Image[] QtePoint;
    public ParticleSystem ParticleSystem;
    public Animator SpellBurning;
    public Transform Bwol;
    public Transform Spell;
    public bool Burning;
    public bool BowlBroken;
    public bool PlayQTE;
    Vector3 NewBwolPos = new Vector3(17.8f, 2.73f, 72.2f);
    Vector3 OrigSpellPos = new Vector3(17.6f, 1.6f, 72.8f);
    Vector3 OrigPlayerPos = new Vector3(18, 0, 71);
    private void Awake()
    {
        ins = this;
    }
    public void Update()
    {
        if (PlayQTE)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PointCount++;
            }
            if (PointCount <= 0)
            {
                QtePoint[0].color = Color.grey;
                QtePoint[1].color = Color.grey;
                QtePoint[2].color = Color.grey;
            }
            if (PointCount >= 1)
            {
                QtePoint[0].color = Color.yellow;
                QtePoint[1].color = Color.grey;
                QtePoint[2].color = Color.grey;
            }
            if (PointCount >= 2)
            {
                QtePoint[0].color = Color.yellow;
                QtePoint[1].color = Color.yellow;
                QtePoint[2].color = Color.grey;

            }
            if (PointCount <= 2)
            {
                Point.color = Color.white;//太極
                randomPoint.enabled = true;
            }

            if (PointCount >= 3)
            {
                PointCount = 3;
                Scessce = true;
                randomPoint.enabled = false;
                QtePoint[0].color = Color.yellow;
                QtePoint[1].color = Color.yellow;
                QtePoint[2].color = Color.yellow;
            }
        }
        if (Scessce == true)
        {
            Debug.Log("點到了");
            Fail = false;
            Trigger.enabled = false;
            FadeInOut.ins.Qte = true;//qte消失
            Burning = true;//符咒燃燒
            PosCamera.SetActive(false);
            QteTimer.ins.Sec = false;
            Drag.ins.DragDown = false;
            Drag.ins.DragUp = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            GodTable.tag = "CloQte";
            Invoke("QTEscesses", 0.5f);
        }

        if (Fail == true)
        {
            PointCount = 0;
            Trigger.enabled = false;
            QteTimer.ins.Sec = false;
            FadeInOut.ins.Qte = true;
            PosCamera.SetActive(false);
            Scessce = false;
            Drag.ins.DragDown = false;
            Drag.ins.DragUp = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            SpellWater.position = new Vector3(0, 0, 0);
            GodTable.tag = "CloQte";
            Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, Quaternion.Euler(20, 0, 0), 0.03f);
            //Player.transform.rotation = Quaternion.Euler(20, 0, 0);
            Bwol.position = Vector3.Lerp(Bwol.position, NewBwolPos, 0.05f);
            Spell.position = Vector3.Lerp(Spell.position, OrigSpellPos, 0.1f);
            BowlBroken = true;
            Invoke("QTEfail", 2);
        }
        if (GodTable.tag=="CloQte")
        {
            PlayerPickUp_Game1.ins.OpQte = false;
            Point.color = Color.clear;
            QtePoint[0].color = Color.clear;
            QtePoint[1].color = Color.clear;
            QtePoint[2].color = Color.clear;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "QteRing") //亂按空白鍵回位
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fail = true;
                MusicManager.ins.QteFail_player.clip = MusicManager.ins.QTE_clip[2];
                MusicManager.ins.QteFail_player.Play();
            }
        }

        if (collision.tag == "Qte")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fail = false;
                Point.color = Color.yellow;//太極
                randomPoint.enabled = false;
                MusicManager.ins.QteScesse_player.clip = MusicManager.ins.QTE_clip[1];
                MusicManager.ins.QteScesse_player.Play();
                MusicManager.ins.QteFail_player.Pause();
            }
        }
    }

    public void QTEscesses()//QTE成功後
    {
        if (Burning == true)
        {
            Debug.Log("成功");
            Scessce = false;
            PlayQTE = false;
            SpellBurning.SetBool("SpellBurning", true);
            ParticleSystem.Play();
            MusicManager.ins.Burning_player.clip = MusicManager.ins.Burning_clip[0];
            MusicManager.ins.Burning_player.Play();
            StartCoroutine("ParticleStop");
        }
    }

    IEnumerator ParticleStop()
    {
        Burning = false;
        yield return new WaitForSeconds(3f);
        ParticleSystem.Stop();
    }

    public void QTEfail()//QTE失敗後
    {
        if (BowlBroken)
        {
            Fail = false;
            StartCoroutine("BwolBreak");
        }
    }
    IEnumerator BwolBreak()
    {
        BowlBroken = false;
        yield return new WaitForSeconds(0.5f);
        Bowl.SetBool("BowlBroken", true);
        MusicManager.ins.BwolBroken_player.clip = MusicManager.ins.BwolBroken_clip[0];
        MusicManager.ins.BwolBroken_player.Play();
        Invoke("PlayerBack", 2.5f);
    }

    public void PlayerBack()
    {
        Quasi_Heart.color = Color.white;
        Player.transform.position = OrigPlayerPos;
        Player.transform.rotation = Quaternion.Euler(0, 90, 0);
        //CmCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
        MusicManager.ins.DoorEffect_player.clip = MusicManager.ins.DoorEffect_clip[0];
        MusicManager.ins.DoorEffect_player.Play();
        PlayerMovement.ins.speed = 5;
        NavMesh_Component.ins.agent.speed = 4;
        MouseLook.ins.MouseMoving = true;
        GodDoor.SetBool("OpenDoor", true);
        GodDoor.SetBool("CloDoor", false);
        Bwol.position = new Vector3(0, 0, 0);
    }
}
