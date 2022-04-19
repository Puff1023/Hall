using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static bool startShake = true; //camera�O�_�}�l�_��
    public static float seconds = 1f; //�_�ʫ�����
    public static bool started = true; //�O�_�w�g�}�l�_��
    public static float quake = 0.05f; //�_�ʫY��
    private Vector3 camPOS; //camera���_�l��m

    private void Start()
    {
        camPOS = transform.localPosition;
    }

    private void LateUpdate()
    {
        if (startShake)
        {
            transform.localPosition = camPOS + Random.insideUnitSphere * quake;
        }
        if (started)
        {
            StartCoroutine(WaitForSecond(seconds));
            started = false;
        }
    }

    /// <summary>

    /// �~���եα���camera�_��

    /// </summary>

    /// <param name="a">�_�ʮɶ�</param>

    /// <param name="b">�_�ʴT��</param>

    public static void ShakeFor(float a, float b)
    {
        // if (startShake)
        // return;
        seconds = a;
        started = true;
        startShake = true;
        quake = b;
    }

    IEnumerator WaitForSecond(float a)
    {
        // camPOS = transform.position;
        yield return new WaitForSeconds(a);
        startShake = false;
        transform.localPosition = camPOS;
    }
}
