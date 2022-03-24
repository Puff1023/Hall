using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatCamera : MonoBehaviour
{
    public static LookatCamera ins;
    [Header("要面向的攝影機")]
    public Camera CameraToLookAt;
    [Header("要固定的軸心")]
    [Tooltip("可以自由選擇要固定的軸心")]
    public SelectXYZ selectXYZ = SelectXYZ.None;

    public Transform MainCamera;
    public float maxDistance;
    public bool CamLookAt;

    private void Awake()
    {
        ins = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (CamLookAt==true)
        {
            if (CameraToLookAt == null)
            {
                CameraToLookAt = Camera.main;
            }

            Vector3 vector3 = CameraToLookAt.transform.position - transform.position;
            switch (selectXYZ)
            {
                case SelectXYZ.x:
                    vector3.y = vector3.z = 0;
                    break;
                case SelectXYZ.y:
                    vector3.x = vector3.z = 0;
                    break;
                case SelectXYZ.z:
                    vector3.x = vector3.y = 0;
                    break;
                case SelectXYZ.None:
                    vector3.x = vector3.y = vector3.z = 0;
                    break;

            }
            transform.LookAt(CameraToLookAt.transform.position - vector3);

            if (Vector3.Distance(gameObject.transform.position, MainCamera.position) > maxDistance)
            {
                Vector3 pos = (gameObject.transform.position - MainCamera.position).normalized;
                pos *= maxDistance;
                gameObject.transform.position = pos + MainCamera.position;
            }
        }
       
    }

    public enum SelectXYZ//鎖定軸心
    { 
        x,
        y,
        z,
        None
    }
}
