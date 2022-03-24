using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Ray_Pick_F : MonoBehaviour
{
    Ray ray;//�g�u���p�W�sray
    float raylength = 2f;//�g�u�g�X�h���̤j����

    RaycastHit hit;//�Q�g�u���쪺���󪺤p�W�shit
    public GameObject Player;
    public Animation ExitDoor;
    public Animation Hit;
    public Animation ExitPanl;
    public Image Exit;
    public Image GameOver;
    public Image Qh;
    public GameObject Exit_Door_Delete;
    public Camera MainCam;
    public VideoPlayer Level3Video;
    void FixedUpdate()
    {
        //�i�D�g�u�g�X�h�O����v���������I�g�X
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        //(�g�u,out �Q���쪺����,�g�u����) out hit=��g�u���쪺����a(out)��hit
        if (Physics.Raycast(ray, out hit, raylength))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.yellow);
            hit.transform.SendMessage("HitByRaycast", gameObject, SendMessageOptions.DontRequireReceiver);
            //print(hit.transform.name);

            if (hit.transform.tag == "ExitDoor")
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    ExitDoor.Play();
                    MusicManager_F.insF.DoorF_player.clip = MusicManager_F.insF.DoorF_clip[0];
                    MusicManager_F.insF.DoorF_player.Play();
                    Invoke("BeAttacked", 2f);
                    Player.GetComponent<PlayerMovement_F>().enabled = false;
                    Exit_Door_Delete.GetComponent<BoxCollider>().enabled = false;
                }

            }
        }
    }

    public void BeAttacked()
    {
        MusicManager_F.insF.StopFootStep();
        MusicManager_F.insF.Hit_player.clip = MusicManager_F.insF.Hit_clip[0];
        MusicManager_F.insF.Hit_player.Play();
        Hit.Play();
        ExitPanl.Play();
        Qh.color = Color.clear;
        Invoke("PlayVideo", 1.5f);
    }

    public void PlayVideo()
    {
        ExitPanl.Stop();
        Exit.color = Color.clear;
        MainCam.cullingMask = (1 << 17);
        Level3Video.enabled = true;
        Invoke("End", 12);
    }
    public void End()
    {
        Exit.color = Color.black;
        GameOver.color = Color.white;
    }
}
