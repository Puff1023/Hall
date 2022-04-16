using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseMovingTrigger : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform Pos;
    public Transform original;
    public Image MiniMap;
    public Image MiniMapMask;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            MouseLook.ins.MouseMovingChang = true;
            MiniMap.color = Color.clear;
            MiniMapMask.color = Color.clear;
        }

        if (other.tag=="Monster")
        {
            if (NewQTE.ins.Fail==false)
            {
                StartCoroutine("GoBack");
                original.position = new Vector3(-30.8f, 0, -36);
                PlayerMovement.ins.speed = 0;
                MouseLook.ins.MouseMoving = false;
            }
        }
    }
    

    IEnumerator GoBack()
    {
        Debug.Log("¦^¥h");
        yield return new WaitForSeconds(4);
        Pos.position = original.position;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            MiniMap.color = Color.white;
            MiniMapMask.color = Color.white;
        }
    }
}
