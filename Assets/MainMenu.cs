using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   public void Quite()
    {
       Application.Quit();
    }
    public void levelSelection (string levelname)
    {
        SceneManager.LoadScene(levelname);
    }


}
