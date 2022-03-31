using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLights : MonoBehaviour
{
    public Light Red;
    public Light Green;
    public Light Yellow;

    
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Yellow.enabled = false;

        while (true)
        {
            Green.enabled = true;
            Red.enabled = false;
            yield return new WaitForSeconds(30);
            Debug.Log("on");
            Yellow.enabled = true;
            Green.enabled = false;
            yield return new WaitForSeconds(5);
            Debug.Log("on");
            Red.enabled = true;
            Yellow.enabled = false;
            yield return new WaitForSeconds(30);

        }
        
    }
  

    // Update is called once per frame
    void Update()
    {
        
    }
}
