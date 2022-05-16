using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text Timertext;
    // Update is called once per frame
    void Update()
    {
        Timertext.text = Time.deltaTime.ToString();
    }
}
