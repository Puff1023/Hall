using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterTrigger : MonoBehaviour
{
    public Material MonsterMat;
    public Animator MonsterAni;
    public float count = 0;
    public float fadeSpeed = 3f;
    public Transform Point;
    public GameObject Player;
    public CameraShake CameraShake;
    public Text[] Text;
    bool FadeOut = false;
    bool MonsterInDoor;
    public bool MonsterLose;
    // Update is called once per frame
    void Update()
    {
        if (FadeOut)
        {
            MonsterMat.color = Color.Lerp(MonsterMat.color, Color.clear, Time.deltaTime * fadeSpeed * 0.5f);
        }

        if (MonsterInDoor)
        {
            MonsterMat.color = Color.Lerp(MonsterMat.color, Color.clear, Time.deltaTime * fadeSpeed * 0.5f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            PlayerMovement_Scenes01.ins.speed = 0;
            FadeOut = true;
            CameraShake.enabled = true;
            MusicManager_Scenes01.ins.MonsterLose_player.clip = MusicManager_Scenes01.ins.MonsterLose_clip[0];
            MusicManager_Scenes01.ins.MonsterLose_player.Play();
            MusicManager_Scenes01.ins.Thunder_player.clip = MusicManager_Scenes01.ins.Thunder_clip[0];
            MusicManager_Scenes01.ins.Thunder_player.Play();
            Invoke("TriggerCount", 2f);
            Debug.Log("碰到了");
        }

        if (other.tag=="Point")

        {
            FadeOut = false;
            MonsterMat.color = Color.white;
        }

        if (other.tag == "NotPlayer")
        {
            MonsterAni.enabled = true;
            PlayerMovement_Scenes01.ins.speed = 0;
        }

        if (other.tag=="VillaDoor")
        {
            MonsterInDoor = true;//鬼進門漸淡
            MusicManager_Scenes01.ins.MonsterLose_player.clip = MusicManager_Scenes01.ins.MonsterLose_clip[0];
            MusicManager_Scenes01.ins.MonsterLose_player.Play();
            StartCoroutine("T6");
        }
    }

    void TriggerCount()
    {
        MonsterLose = true;
        if (MonsterLose)
        {
            Debug.Log("消失");
            MonsterMat.color = Color.clear;
            PlayerMovement_Scenes01.ins.speed = 2;
            CameraShake.enabled = false;
            gameObject.transform.position = Point.position;
            gameObject.transform.rotation = Quaternion.Euler(0, 205f, 0);
            Text[0].color = Color.white;
            MusicManager_Scenes01.ins.Thunder_player.clip = MusicManager_Scenes01.ins.Thunder_clip[0];
            MusicManager_Scenes01.ins.Thunder_player.Stop();
            StartCoroutine("T5");
        }
    }
    IEnumerator T5()
    {
        yield return new WaitForSeconds(2f);
        Player.tag = "NotPlayer";
        Text[0].color = Color.clear;
        Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, Quaternion.Euler(0, 20, 0), 0.05f);
    }
    
    IEnumerator T6()
    {
        yield return new WaitForSeconds(3f);
        Text[1].color = Color.white;
        CameraShake.enabled = true;
        MusicManager_Scenes01.ins.Thunder_player.clip = MusicManager_Scenes01.ins.Thunder_clip[0];
        MusicManager_Scenes01.ins.Thunder_player.Play();
        StartCoroutine("T7");
    }
    IEnumerator T7()
    {
        yield return new WaitForSeconds(3f);
        Text[1].color = Color.clear;
        Text[2].color = Color.white;
        MusicManager_Scenes01.ins.Thunder_player.clip = MusicManager_Scenes01.ins.Thunder_clip[0];
        MusicManager_Scenes01.ins.Thunder_player.Stop();
        StartCoroutine("TextEnd");
    }

    IEnumerator TextEnd()
    {
        yield return new WaitForSeconds(3f);
        Text[2].color = Color.clear;
        PlayerMovement_Scenes01.ins.speed = 2;
    }
}
