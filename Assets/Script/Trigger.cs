using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Transform Entrance;//入口牆
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("入口堵住");
            Entrance.position = new Vector3(-92.85992f, 0, -25.13997f);
        }
    }
}
