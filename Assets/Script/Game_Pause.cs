using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Pause : MonoBehaviour
{

    private bool isPause;
    public Canvas Pause_Menu;


    private void Start()
    {
       isPause = false;
        Pause_Menu.enabled = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                isPause = true;
                Pause_Menu.enabled = true;

                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                MusicManager.ins.BGM_player.Pause();
                MusicManager.ins.DoorEffect_player.Pause();
                MusicManager.ins.Monster_player.Pause();
                MusicManager.ins.FootStep_player.Pause();
                MusicManager.ins.ElevatorOpen_player.Pause();
                MusicManager.ins.oillight_player.Pause();
            }

        }
    }

    
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPause = false;
        Pause_Menu.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        MusicManager.ins.BGM_player.UnPause();
        MusicManager.ins.DoorEffect_player.UnPause();
        MusicManager.ins.Monster_player.UnPause();
        MusicManager.ins.FootStep_player.UnPause();
        MusicManager.ins.ElevatorOpen_player.UnPause();
        MusicManager.ins.oillight_player.UnPause();
        
    }

   public void  BackMenu()
    {
        SceneManager.LoadScene("Start_Menu");
        Time.timeScale = 1;
    }

}
