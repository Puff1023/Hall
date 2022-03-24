using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logo : MonoBehaviour
{
    public void Start()
    {
        Invoke("Logo", 1f);
    }

    public void Logo()
    {
        GetComponent<Animation>().Play("logo animation");

    }
    // Update is called once per frame
   
}
