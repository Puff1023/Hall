using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ray_Pick_Scenes01 : MonoBehaviour
{
    public static Ray_Pick_Scenes01 ins;

    Ray ray;//射線的小名叫ray
    float raylength = 3f;//射線射出去的最大長度
    RaycastHit hit;//被射線打到的物件的小名叫hit

    public Transform RightDoor;
    public Transform LeftDoor;
    public float Speed = 1;
    private void Awake()
    {
        ins = this;
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
                
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    Debug.Log("OpenDoor");
                    RightDoor.rotation = Quaternion.Lerp(RightDoor.rotation, Quaternion.Euler(0, -80, 0), 0.01f);
                    LeftDoor.rotation = Quaternion.Lerp(LeftDoor.rotation, Quaternion.Euler(0, 80, 0), 0.01f);
                }
            }
        }    
    }
}

