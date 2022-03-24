using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_button : MonoBehaviour
{
    public static show_button sb;
    private bool condition;

    private void Start()
    {
        condition = true;
        Invoke("CanUseMouse", 5.5f);
    }

    public void CanUseMouse()
    {
        condition = false;
    }

    public void Update()
    {
        if (!condition)
        {
            if (Input.GetMouseButton(0))
            {
                
                GetComponent<Animation>().Play("button animation");
                condition = true;

            }
        }
    }
   
}

