using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Transform Entrance;//�J�f��
    public Transform Gear;//������
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("�J�f����");
            Entrance.position = new Vector3(12.85904f, 1.8375f, 15.32989f);
            Gear.position = new Vector3(0, 0, 0);
        }
    }
}
