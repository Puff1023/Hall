using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class continue_scene : MonoBehaviour
{
    public static continue_scene cs;

    public GameObject BG;
    public Animation BG_ani;
    private AsyncOperation async;
    private int curProgressValue = 0;

    // Start is called before the first frame update

    private void Start()
    {
        BG.SetActive(false);
    }

    public void UseElevator()
    {
        StartCoroutine(LoadScene());

    }



    IEnumerator LoadScene()
    {
        async = SceneManager.LoadSceneAsync("FinalScene");
        async.allowSceneActivation = false;
        yield return async;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (async == null)
        {
            return;
        }

        int progressValue = 100;

        if (curProgressValue < progressValue)
        {
            curProgressValue++;
        }

        if (curProgressValue == 100)
        {
            Debug.Log("gogogo");
            Invoke("ToFinalScene",10f);
            Invoke("ShowBG", 7.5f);
            
        }

    }

   

    public void  ToFinalScene()
    {
        BG.SetActive(true);
        async.allowSceneActivation = true;
    }

    public void ShowBG()
    {
        BG_ani.Play();
    }
}
