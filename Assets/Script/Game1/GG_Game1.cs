using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GG_Game1 : MonoBehaviour
{
    // Start is called before the first frame update
   public void Restart()
    {
        SceneManager.LoadScene("Game1");
        Time.timeScale = 1;
    }

    // Update is called once per frame
   public void Quit()
    {
        SceneManager.LoadScene("Start_menu");
        Time.timeScale = 1;
    }
}