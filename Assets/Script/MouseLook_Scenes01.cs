using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook_Scenes01 : MonoBehaviour
{
    public static MouseLook_Scenes01 ins;
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    public bool MouseMoving;
    private void Awake()
    {
        ins = this;
    }
    // Update is called once per frame
    public void Update()
    {
        if (MouseMoving==true)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
