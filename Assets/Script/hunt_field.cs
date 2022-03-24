using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hunt_field : MonoBehaviour
{
    private void OnTriggerStay(Collider col)
    {
       if(col.tag=="Player")
        {
            col.tag = "Prey";
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Prey")
        {
            col.tag = "Player";
        }
    }
}
