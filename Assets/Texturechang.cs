using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texturechang : MonoBehaviour
{
    public static Texturechang ins;
    public Texture myTexture;
    // Start is called before the first frame update
    private void Awake()
    {
        ins = this;
    }

    private void OnEnable()
    {
        Debug.Log("´«¹Ï");
        GetComponent<Renderer>().material.mainTexture = myTexture;
    }

}
