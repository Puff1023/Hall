using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QtTigger : MonoBehaviour
{
    public static QtTigger ins;
    public float Speed=1;
    int count=1;
    private void Awake()
    {
        ins = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (count>=1)
        {
            transform.Rotate(new Vector3(0, 0, 15), Time.deltaTime * Speed);
            count++;
        }

        if (count<=0)
        {
            transform.Rotate(new Vector3(0, 0, -15), Time.deltaTime * Speed);
        }

        if (this.transform.localEulerAngles.z >= 180)
        {
            count%=2;
            //print("z角度為：" + this.transform.localEulerAngles.z);
        }
        if (this.transform.localEulerAngles.z >= 355)
        {
            count++;
            //print("z角度為：" + this.transform.localEulerAngles.z);
        }

    }
}
