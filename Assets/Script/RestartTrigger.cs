using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            Entrance.position = new Vector3(0, 0, 0);
            GodDoor.SetBool("OpenDoor", false);
            GodDoor.SetBool("CloDoor", true);
            FadeInOut.ins.Qte = false;
            Fade.enabled = false;
            Spell.position = new Vector3(42.3f, 1.7f, -19.7f);
            Spell.tag = "Qte";
            Trigger.enabled = true;
            NewQTE.ins.Fail = false;
            Drag.ins.DragDown = true;
            Drag.ins.DragUp = true;
            LookCheck.SetActive(true);
            CameraSize.orthographicSize = 4;
            WoodTrigger.SetBool("WoodTrigger", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            NavMesh_Component.ins.agent.speed = 0;
        }
    }
}
