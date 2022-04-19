using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static bool startShake = true; //camera是否開始震動
    public static float seconds = 1f; //震動持續秒數
    public static bool started = true; //是否已經開始震動
    public static float quake = 0.05f; //震動係數
    private Vector3 camPOS; //camera的起始位置

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

    /// 外部調用控制camera震動

    /// </summary>

    /// <param name="a">震動時間</param>

    /// <param name="b">震動幅度</param>

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
