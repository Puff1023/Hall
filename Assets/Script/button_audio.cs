using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;




public class button_audio : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource buttonaudio_player;

    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonaudio_player.Play();
        
    }
}
