using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    bool gameended = false;
    public float restartdelay = 2f;

    public GameObject LoseUI;

    public void Winlevel()
    {
        if (gameended == false)
        {
            LoseUI.SetActive(true);
            gameended = true;
            Debug.Log("You lost");
            Invoke("Restart", restartdelay);
        }
        
    }
    public void Restart()
    {

    }    
}
