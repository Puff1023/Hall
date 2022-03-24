using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class final_scene : MonoBehaviour
{
    public Animation BG;
    public Animation Elevator;

    // Start is called before the first frame update
    void Start()
    {
        BG.Play();
        Invoke("ElevatorOpen", 3f);
    }

    public void ElevatorOpen()
    {
        Elevator.Play();
        MusicManager_F.insF.ElevatorF_player.clip = MusicManager_F.insF.ElevatorF_clip[0];
        MusicManager_F.insF.ElevatorF_player.Play();
    }
}
