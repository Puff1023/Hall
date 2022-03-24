using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_ani : MonoBehaviour
{
    public GameObject Menu_close;
    private bool condition;

    void Start()
    {
        GetComponent<Animation>().Play("menu animation");
        condition = true;
        Invoke("CanUseMouse", 5.5f);
    }

    public void  CanUseMouse()
    {
        condition = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (!condition)
        {
            if (Input.GetMouseButton(0))
            {
                Menu_close.SetActive(false);
               
                condition = true;
               
            }
        }
    }

 
   

}
