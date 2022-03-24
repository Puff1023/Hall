using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Transform Entrance;//入口牆
    public Transform Gear;//阻擋牆
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("入口堵住");
            Entrance.position = new Vector3(12.85904f, 1.8375f, 15.32989f);
            Gear.position = new Vector3(0, 0, 0);
        }
    }
}
