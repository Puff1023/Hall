using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public static Drag ins;
    Vector3 prePos;
    public bool DragUp;
    public bool DragDown;
    private void Awake()
    {
        ins = this;
    }
    private void OnMouseDown()
    {
        if (DragDown==true)
        {
            Vector3 mouse = Input.mousePosition;
            mouse.z = 1.3f;
            prePos = Camera.main.ScreenToWorldPoint(mouse);
            gameObject.tag = "Spell";
        }
    }

    private void OnMouseDrag()
    {
        if (DragUp==true)
        {
            Vector3 mouse = Input.mousePosition;
            mouse.z = 1.3f;
            Vector3 newPos = Camera.main.ScreenToWorldPoint(mouse);
            Vector3 offset = newPos - prePos;
            transform.position = newPos;
            prePos = Camera.main.ScreenToWorldPoint(mouse);
        }
    }
}
