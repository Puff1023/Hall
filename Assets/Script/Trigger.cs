using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Transform Entrance;//入口牆
    public Animator LampBreak;
    public Light Lamp;
    public Vector3 NewTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("入口堵住+燈破");
            Entrance.position = new Vector3(-92.85992f, 0, -25.13997f);
            LampBreak.enabled = true;
            Lamp.intensity = 0;
            MusicManager.ins.LampBreak_player.clip = MusicManager.ins.LampBreak_clip[0];
            MusicManager.ins.LampBreak_player.Play();
            gameObject.transform.position = NewTrigger;
        }
    }
}
