using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotate : MonoBehaviour
{
    public float Speed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -15), Time.deltaTime * Speed);
    }
}
