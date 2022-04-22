using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carscript : MonoBehaviour
{
    public float Yangle, Xangle, Zangle;
    public float speed1, speed2;
    Vector3 vec;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * Random.Range(speed1, speed2));
        transform.Rotate(Yangle, Xangle, Zangle);
    }
}
