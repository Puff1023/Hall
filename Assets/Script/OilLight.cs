using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilLight : MonoBehaviour
{
    public float Speed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime * Speed);
    }
}
