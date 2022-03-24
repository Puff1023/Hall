using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QteTimer : MonoBehaviour
{
    public static QteTimer ins;
    public int sec = 16;//¬í
    public Text Qte_timer;
    public bool Sec;
    private void Awake()
    {
        ins = this;
    }
    // Start is called before the first frame update
    public void Start()
    {
        MusicManager.ins.QteTimer_player.clip = MusicManager.ins.QteTimer_clip[0];
        MusicManager.ins.QteTimer_player.Play();
        InvokeRepeating("timer", 0.1f, 1f);
    }

    private void OnEnable()
    {
        timer();
        Sec = true;
        sec = 16;
    }
    public void timer()
    {
        if (Sec)
        {
            sec -= 1;
            Qte_timer.text = sec + "";
        }
        else
        {
            MusicManager.ins.QteTimer_player.clip = MusicManager.ins.QteTimer_clip[0];
            MusicManager.ins.QteTimer_player.Pause();
        }

        if (sec == 0)
        {
            CancelInvoke("timer");
            Qte_timer.color = Color.red;
            NewQTE.ins.Fail = true;
        }
    }
}
