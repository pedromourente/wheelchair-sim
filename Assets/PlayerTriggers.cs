using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    public WinLose winlosescript;
    private void OnTriggerEnter(Collider other)
    {
     if (other.gameObject.CompareTag("Cars"))
        {
            winlosescript.Winlevel();
           
        }
    }
}
