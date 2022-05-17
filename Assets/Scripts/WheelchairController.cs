using System.Collections;
using System.Collections.Generic;
using UnityEngine;


   
  


public class WheelchairController : MonoBehaviour
{

    public Transform topOfJoystick;
    public Transform JoyStick; 

    [SerializeField]
    public float forwardBackwardtilt = 0;
    [SerializeField]
    public float sideToSideTilt = 0;


    [SerializeField] WheelCollider frontleft;
    [SerializeField] WheelCollider frontright;
    [SerializeField] WheelCollider backleft;
    [SerializeField] WheelCollider backright;

    [SerializeField] Transform frontleftTR;
    [SerializeField] Transform frontrightTR;
    [SerializeField] Transform backleftTR;
    [SerializeField] Transform backrightTR;

    public float Acceleration = 500f;
    public float BreakingForce = 300f;
    public float MaxTurnAngle = 15;

    public float CurrentAcceleration = 0;
    public float CurrentBreakForce = 0;
    public float CurrentTurnAngle = 0;

    public WinLose winlosescript;
    public void Update()
    {
        if (gameObject.transform.localRotation.eulerAngles.z > 90f && gameObject.transform.localRotation.eulerAngles.z < 180f)
        {

            winlosescript.loselevel();
        }

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

   private void FixedUpdate()
    {

        //CurrentAcceleration = Acceleration * Input.GetAxis("Vertical");


        if (Input.GetKey(KeyCode.Space))
            
            CurrentBreakForce = BreakingForce;
            else
                CurrentBreakForce = 0;

        frontright.motorTorque = CurrentAcceleration;
        frontleft.motorTorque = CurrentAcceleration;

        backright.brakeTorque = CurrentBreakForce;
        backleft.brakeTorque = CurrentBreakForce;

        CurrentTurnAngle = MaxTurnAngle * Input.GetAxis("Horizontal");
        frontleft.steerAngle = CurrentTurnAngle;
        frontright.steerAngle = CurrentTurnAngle;

        UpdateWheel(frontright, frontrightTR);
        UpdateWheel(backleft, backleftTR);
        UpdateWheel(frontleft, frontleftTR);
        UpdateWheel(backright, backrightTR);
    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("RightHand") || other.CompareTag("LeftHand"))
        {
            JoyStick.transform.LookAt(other.transform.position, transform.up);
        }
    }

}
