using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject LevelMenu;

    public GameObject Black_BG;

    public Slider loadingBar;
    public GameObject loadingImage;
    public Text LoadingText;


    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(true);
        LevelMenu.SetActive(false);
        loadingImage.SetActive(false);
        Black_BG.SetActive(true);

        Invoke("CloseBG", 5f);
    }

    public void CloseBG()
    {
        Black_BG.SetActive(false);
    }

    public void StartGame()
    {
        loadingImage.SetActive(true);
        StartCoroutine(LoadLevelWithBar("Scene 01"));
    }

    public void Normal()
    {
        loadingImage.SetActive(true);
        StartCoroutine(LoadLevelWithBar2("Game1"));
    }
    public void Diffculty()
    {
        loadingImage.SetActive(true);
        StartCoroutine(LoadLevelWithBar3("Game2"));
    }
    IEnumerator LoadLevelWithBar(string level)
    {
        int displayProgress = 0;
        int toProgress = 0;

        AsyncOperation async = SceneManager.LoadSceneAsync("Scene 01");
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            toProgress = (int)async.progress * 100;
            while (displayProgress < toProgress)
            {
                displayProgress++;
                setloading(displayProgress);
                yield return new WaitForEndOfFrame();
            }
        }
        toProgress = 100;
        while (displayProgress < toProgress)
        {
            displayProgress++;
            setloading(displayProgress);
            yield return new WaitForEndOfFrame();
        }
        async.allowSceneActivation = true;
    }

    IEnumerator LoadLevelWithBar2(string level)
    {
        int displayProgress = 0;
        int toProgress = 0;

        AsyncOperation async = SceneManager.LoadSceneAsync("Game1");
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            toProgress = (int)async.progress * 100;
            while (displayProgress < toProgress)
            {
                displayProgress++;
                setloading(displayProgress);
                yield return new WaitForEndOfFrame();
            }
        }
        toProgress = 100;
        while (displayProgress < toProgress)
        {
            displayProgress++;
            setloading(displayProgress);
            yield return new WaitForEndOfFrame();
        }
        async.allowSceneActivation = true;
    }

    IEnumerator LoadLevelWithBar3(string level)
    {
        int displayProgress = 0;
        int toProgress = 0;

        AsyncOperation async = SceneManager.LoadSceneAsync("Game2");
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            toProgress = (int)async.progress * 100;
            while (displayProgress < toProgress)
            {
                displayProgress++;
                setloading(displayProgress);
                yield return new WaitForEndOfFrame();
            }
        }
        toProgress = 100;
        while (displayProgress < toProgress)
        {
            displayProgress++;
            setloading(displayProgress);
            yield return new WaitForEndOfFrame();
        }
        async.allowSceneActivation = true;
    }

    private void setloading(float percent)
    {
        loadingBar.transform.localScale = new Vector3((percent * 0.01f), 1, 10);
        LoadingText.text = percent.ToString() + "%";
    }

    public void  open_level()
    {
        menu.SetActive(false);
        LevelMenu.SetActive(true);
    }

    public void  close_level()
    {
        LevelMenu.SetActive(false);
        menu.SetActive(true);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
