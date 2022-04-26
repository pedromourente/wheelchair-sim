using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CricleAnimation : MonoBehaviour
{

    public Vector3 _rotate;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotate * Time.deltaTime);
    }
}
