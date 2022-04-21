using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartTrigger : MonoBehaviour
{
    public Transform Entrance;//入口牆
    public Animator GodDoor;
    public Transform Spell;
    public QtTigger Trigger;//qte指針
    public FadeInOut Fade;
    public GameObject LookCheck;
    public Camera CameraSize;//小地圖視野範圍
    public Animator WoodTrigger;
    public GameObject GodTable;
    public Animator Bwol;
    public Transform BwolPos;
    public GameObject NewQte;
    public Transform Water;
    public Vector3 OrigiWaterPos;
    public Vector3 OrgiBwolPos;
    public Vector3 SpellOriginal;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            Entrance.position = new Vector3(0, 0, 0);
            GodDoor.SetBool("OpenDoor", false);
            GodDoor.SetBool("CloDoor", true);
            FadeInOut.ins.Qte = false;
            Fade.enabled = false;
            Spell.position = SpellOriginal;// new Vector3(42.3f, 1.7f, -19.7f);
            Spell.tag = "Qte";
            BwolPos.position = OrgiBwolPos;
            Water.localPosition = OrigiWaterPos;
            Bwol.SetBool("BowlBroken", false);
            GodTable.tag = "OpQte";
            Trigger.enabled = true;
            //NewQTE.ins.Fail = false;
            Drag.ins.DragDown = true;
            Drag.ins.DragUp = true;
            LookCheck.SetActive(true);
            CameraSize.orthographicSize = 4;
            WoodTrigger.SetBool("WoodTrigger", false);
            NewQte.SetActive(false);
            MouseLook.ins.MouseMoving = true;
            PlayerMovement.ins.speed = 5;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            Debug.Log("回去");
            PlayerMovement.ins.speed = 5;
            MouseLook.ins.MouseMoving = true;
            NavMesh_Component.ins.agent.speed = 0;
        }
    }
}
