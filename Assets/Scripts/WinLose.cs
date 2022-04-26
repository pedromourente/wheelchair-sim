using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    //bool gameended = false;
    public float restartdelay = 2f;

    public GameObject LoseUI;
    public GameObject WinUI;

    public void Winlevel()
    {
        WinUI.SetActive(true);
    }
    public void loselevel()
    {
        LoseUI.SetActive(true);
    }
    //public void Winlevel()
    //{
    //    if (gameended == false)
    //    {
    //        LoseUI.SetActive(true);
    //        gameended = true;
    //        Debug.Log("You lost");
    //        Invoke("Restart", restartdelay);
    //    }
        
    //}
    public void Restart()
    {

    }    
}
