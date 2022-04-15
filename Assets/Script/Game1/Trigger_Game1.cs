using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Game1 : MonoBehaviour
{
    public Transform Entrance;//入口牆
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("入口堵住");
            Entrance.position = new Vector3(-106.0298f, 0, -22.52598f);
        }
    }
}
