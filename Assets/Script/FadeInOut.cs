using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public static FadeInOut ins;
    public bool Qte = false;

    public float fadeSpeed =3f; //透明度變化速率

    public Image Point; //點
    public Image Bnt; //指針
    public Image Ring; //弧
    public Image Spece;//空白建
    public Image Finger;//手指
    public Text Qte_Timer_Color;
    public QteTimer Qte_Timer;//QTE倒數腳本
    private void Awake()
    {
        ins = this;
    }
    public void Update()
    {
        if (Qte == true)
        {
            Point.color = Color.Lerp(Point.color, Color.clear, Time.deltaTime * fadeSpeed * 0.5f);
            Ring.color = Color.Lerp(Ring.color, Color.clear, Time.deltaTime * fadeSpeed * 0.5f);
            Bnt.color = Color.Lerp(Bnt.color, Color.clear, Time.deltaTime * fadeSpeed * 0.5f);
            Spece.color = Color.Lerp(Spece.color, Color.clear, Time.deltaTime * fadeSpeed * 0.5f);
            Finger.color = Color.Lerp(Finger.color, Color.clear, Time.deltaTime * fadeSpeed * 0.5f);
            Qte_Timer_Color.color=Color.Lerp(Qte_Timer_Color.color, Color.clear, Time.deltaTime * fadeSpeed * 0.5f);
        }
        else
        {
            Point.color = Color.Lerp(Point.color, Color.white, Time.deltaTime * fadeSpeed * 1f);
            Ring.color = Color.Lerp(Ring.color, Color.white, Time.deltaTime * fadeSpeed * 1f);
            Bnt.color = Color.Lerp(Bnt.color, Color.white, Time.deltaTime * fadeSpeed * 1f);
            Spece.color = Color.Lerp(Spece.color, Color.white, Time.deltaTime * fadeSpeed * 1f);
            Finger.color = Color.Lerp(Finger.color, Color.white, Time.deltaTime * fadeSpeed * 1f);
            Qte_Timer_Color.color = Color.Lerp(Qte_Timer_Color.color, Color.white, Time.deltaTime * fadeSpeed * 1f);
        }
        if (Ring.color.a < 0.15f)
        {
            Qte_Timer.enabled = false;
        }
    }
}

