using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseNResume : MonoBehaviour
{
    public static bool GameisPaused;
    public GameObject PauseMenuUI;
    public GameObject MouseMovement;
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        MouseMovement.GetComponent<CameraControls>().enabled = true;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }
    void Pause()
    {
        MouseMovement.GetComponent<CameraControls>().enabled = false;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;    
        GameisPaused = true;  
    }
}
