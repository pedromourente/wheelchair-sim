using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickControl : MonoBehaviour
{

    public Transform topOfJoystick;

    [SerializeField]
    private float forwardBackwardtilt = 0;
    [SerializeField]
    private float sideToSideTilt = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        forwardBackwardtilt = topOfJoystick.rotation.eulerAngles.x;
        if (forwardBackwardtilt < 355 && forwardBackwardtilt > 290)
        {
            forwardBackwardtilt = Mathf.Abs(forwardBackwardtilt - 360);
            Debug.Log("this is the thing " + forwardBackwardtilt);
            //move something using forwardbackwardtilt as speed
        }
        else if (forwardBackwardtilt > 5 && forwardBackwardtilt < 74)
        {
            //do smth
        }

        sideToSideTilt = topOfJoystick.rotation.eulerAngles.z;
        if (sideToSideTilt < 355 && sideToSideTilt > 290)
        {
            sideToSideTilt = Mathf.Abs(sideToSideTilt - 360);
        }
        else if (sideToSideTilt > 5 && sideToSideTilt < 74)
        {

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("RightHand") || other.CompareTag("LeftHand")) 
        {
            transform.LookAt(other.transform.position, transform.up);
        }
    }
}
