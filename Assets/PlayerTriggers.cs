using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    public WinLose winlosescript;
    public int StarValue = 1;

 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cars"))
        {
            Debug.Log("HIt");
            winlosescript.loselevel();


        }

        else if (other.gameObject.CompareTag("WinBox"))
        {
            Scoremanager.instance.changescore(StarValue);
            Destroy(other.gameObject);
        }

    }

  
 
}
