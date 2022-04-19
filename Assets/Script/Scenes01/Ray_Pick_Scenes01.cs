using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Ray_Pick_Scenes01 : MonoBehaviour
{
    public static Ray_Pick_Scenes01 ins;

    Ray ray;//射線的小名叫ray
    float raylength = 3f;//射線射出去的最大長度
    RaycastHit hit;//被射線打到的物件的小名叫hit

    public Transform RightDoor;
    public Transform LeftDoor;
    public Outline Right;
    public Outline Left;
    public GameObject UI;
    public Image Black;
    public float fadeSpeed;
    public float Speed = 1;
    bool CanopDoor = false;

    private void Awake()
    {
        ins = this;
    }

    private void Update()
    {
        if (CanopDoor)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("音效咧?");
                MusicManager_Scenes01.ins.VillaDoor_player.clip = MusicManager_Scenes01.ins.VillaDoor_clip[0];
                MusicManager_Scenes01.ins.VillaDoor_player.Play();
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Debug.Log("音效啦");
                MusicManager_Scenes01.ins.VillaDoor_player.clip = MusicManager_Scenes01.ins.VillaDoor_clip[0];
                MusicManager_Scenes01.ins.VillaDoor_player.Pause();
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                //Debug.Log("OpenDoor");
                //print("y角度為：" + RightDoor.transform.localEulerAngles.y);
                RightDoor.rotation = Quaternion.Lerp(RightDoor.rotation, Quaternion.Euler(0, -70, 0), 0.01f);
                LeftDoor.rotation = Quaternion.Lerp(LeftDoor.rotation, Quaternion.Euler(0, 70, 0), 0.01f);
            }
        }
    }

    void FixedUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;//鎖定鼠標
        //告訴射線射出去是由攝影機正中心點射出
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        //(射線,out 被打到的物件,射線長度) out hit=把射線打到的物件帶(out)給hit
        if (Physics.Raycast(ray, out hit, raylength))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.yellow);
            hit.transform.SendMessage("HitByRaycast", gameObject, SendMessageOptions.DontRequireReceiver);

            if (hit.transform.tag=="VillaDoor")
            {
                UI.SetActive(true);
                Right.OutlineWidth = 6;
                Left.OutlineWidth = 6;
                CanopDoor = true;
                
            }
            else
            {
                UI.SetActive(false);
                Right.OutlineWidth = 0;
                Left.OutlineWidth = 0;
                CanopDoor = false;
            }

            if (RightDoor.localEulerAngles.y >= 50)//轉場道關卡1
            {
                hit.transform.tag = "NotVilla";
                Black.color = Color.Lerp(Black.color, Color.black, Time.deltaTime * fadeSpeed * 0.5f);
                if (Black.color.a>=0.95f)
                {
                    SceneManager.LoadScene(2);//關卡1
                    MusicManager_Scenes01.ins.ChangScenes_player.clip = MusicManager_Scenes01.ins.ChangScenes_clip[0];
                    MusicManager_Scenes01.ins.ChangScenes_player.Play();
                    MusicManager_Scenes01.ins.VillaDoor_player.clip = MusicManager_Scenes01.ins.VillaDoor_clip[0];
                    MusicManager_Scenes01.ins.VillaDoor_player.Stop();
                }
            }
        }    
    }
}

