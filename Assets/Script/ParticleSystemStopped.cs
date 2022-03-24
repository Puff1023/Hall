using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleSystemStopped : MonoBehaviour
{
    public Transform Spell;//才〨
    public Animator SpellBurning; //才〨縐縉笆礶
    public Texturechang WaterScript;
    public Animator BowlAni;
    public Animator WaterAni;
    public Image Quasi_Heart;
    public Transform Player;
    public Transform CmCamera;
    public NewQTE QteScript;
    public Light ElvaLight;
    public void OnParticleSystemStopped()
    {
        QteScript.enabled = false;
        SpellBurning.SetBool("SpellBurning", false);
        Spell.position = new Vector3(0, 0, 0);//才〨ア
        WaterScript.enabled = true;//传才禟瓜
        StartCoroutine("Bwol");
    }

    IEnumerator Bwol()
    {
        yield return new WaitForSeconds(0.5f);
        BowlAni.enabled = true;
        WaterAni.enabled = true;
        StartCoroutine("BurningSound");
    }

    IEnumerator BurningSound()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine("ElevatorOpen");

    }
    IEnumerator ElevatorOpen()
    {
        yield return new WaitForSeconds(7f);
        PlayerMovement.ins.speed = 5;
        MouseLook.ins.MouseMoving = true;
        Quasi_Heart.color = Color.white;
        Player.position = new Vector3(44, 0.5f, -19.54f);
        Player.rotation = Quaternion.Euler(0, -90, 0);
        CmCamera.transform.rotation = Quaternion.Euler(0, -90, 0);
        BowlAni.enabled = false;
        WaterAni.enabled = false;
        Ray_Pick.ins.ElvaOp = true;//す砛ㄏノ筿辫
        MusicManager.ins.ElvaLight_player.clip = MusicManager.ins.ElvaLight_clip[0];
        MusicManager.ins.ElvaLight_player.Play();
        MusicManager.ins.KnockDoor_player.clip = MusicManager.ins.KnockDoor_clip[0];
        MusicManager.ins.KnockDoor_player.Pause();
        ElvaLight.intensity = 3;
        Debug.Log("Exit");
    }
}
