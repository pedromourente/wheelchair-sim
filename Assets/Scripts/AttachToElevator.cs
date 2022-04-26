using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToElevator : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject == player)
        {
            player.transform.parent = transform;
        }    
    }
    private void OnTriggerExit(Collider other)
    {
        if (gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
