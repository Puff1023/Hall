using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Transform Entrance;//�J�f��
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("�J�f����");
            Entrance.position = new Vector3(-92.85992f, 0, -25.13997f);
        }
    }
}
