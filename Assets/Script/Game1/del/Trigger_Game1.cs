using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Game1 : MonoBehaviour
{
    public Transform Entrance;//�J�f��
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("�J�f����");
            Entrance.position = new Vector3(-106.0298f, 0, -22.52598f);
        }
    }
}
