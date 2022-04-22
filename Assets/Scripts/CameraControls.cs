using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yaw -= speedH * Input.GetAxis("Mouse Y");
        pitch += speedV * Input.GetAxis("Mouse X");

        //yaw = Mathf.Clamp(yaw, -90f, 90f);
        //pitch = Mathf.Clamp(pitch, -60f, 90f);

        transform.eulerAngles = new Vector3(yaw, pitch, 0.0f);
        
    }
}
