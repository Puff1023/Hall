using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurningSpell : MonoBehaviour
{
    public GameObject Spell;
    public GameObject QTE;
    public GameObject PosCamera;
    public Image MiniMap;
    public Image MiniMapMask;
    public Image Quasi_Heart;
    public FadeInOut Fade;
    public QteTimer QteTimer;
    public Text QteTimerImg;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag=="Spell")
        {
            StartCoroutine("OpenQte");
        }
    }

    IEnumerator OpenQte()
    {
        yield return new WaitForSeconds(0.5f);
        Spell.tag = "Qte";
        QTE.SetActive(true);
        Fade.enabled=true;
        PosCamera.SetActive(true);
        MiniMap.color = Color.clear;
        MiniMapMask.color = Color.clear;
        Quasi_Heart.color = Color.clear;
        QteTimer.enabled = true;
        QteTimerImg.color = Color.white;
        MusicManager.ins.QTE_player.clip = MusicManager.ins.QTE_clip[0];
        MusicManager.ins.QTE_player.Play();
    }
}
