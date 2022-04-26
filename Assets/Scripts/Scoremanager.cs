using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoremanager : MonoBehaviour
{
    public static Scoremanager instance;
    public TextMeshProUGUI text;
    public int StarValue;
    public int winAmount;
    public WinLose winlosescript;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }
    public void changescore(int StarValue)
    {
        score += StarValue;
        text.text = "Stars: " + score.ToString();
        if (score == winAmount)
        {
            winlosescript.Winlevel();
        }
    }    

    
}
