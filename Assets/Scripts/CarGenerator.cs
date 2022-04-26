using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour
{
    public GameObject car;
    public float Yangle, Xangle, Zangle;
    private int carspawner;
    public float max, min;
    private void Start()
    {
        StartCoroutine(Spawnroutine());
        //Invoke("spawn", 2);
    }
    //private void spawn()
    //{
    //    WaitForSeconds(carspawner);
    //    Instantiate(car);
    //}
    IEnumerator Spawnroutine()
    {
        while (car == true)
        {
            yield return new WaitForSeconds(Random.Range(min, max));

            GameObject c = Instantiate(car, transform.localPosition, transform.rotation);
            
        }
    }

}
