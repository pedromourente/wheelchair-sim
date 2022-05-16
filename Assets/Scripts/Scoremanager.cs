using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoremanager : MonoBehaviour
{
    public static Scoremanager instance;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI AmountUI;
    public int StarValue;
    public int winAmount;
    public WinLose winlosescript;
    public TextMeshProUGUI Timer;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        //winAmount.winAmount = "Stars to collect: " + AmountUI;

        AmountUI.text = "Star Amount: " + winAmount.ToString();
        if (instance == null)
        {
            instance = this;
        }
        
    }
    public void changescore(int StarValue)
    {
        score += StarValue;
        ScoreText.text = "Stars: " + score.ToString();
        if (score == winAmount)
        {
            winlosescript.Winlevel();
        }
    }
    private void Update()
    {
        Timer.text = Time.time.ToString("0.0");
    }


}
