using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;



[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class Control : MonoBehaviour
{
    public Transform topOfJoystick;

    [SerializeField]
    private float forwardBackwardtilt = 0;
    [SerializeField]
    private float sideToSideTilt = 0;


    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

    public Transform leftWheelTR;
    public Transform rightWheelTR;

    public WinLose winlosescript;
    // finds the corresponding visual wheel
    // correctly applies the transform

    public void Update()
    {
        //if (Input.GetKey("Escape"))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 0);
        //}
        
        if (gameObject.transform.localRotation.eulerAngles.z > 90f && gameObject.transform.localRotation.eulerAngles.z < 180f)
        {
            
            winlosescript.loselevel();
        }






        
            forwardBackwardtilt = topOfJoystick.rotation.eulerAngles.x;
        Debug.Log("this is forwardbackward " + forwardBackwardtilt);

        if (forwardBackwardtilt < 355 && forwardBackwardtilt > 290)
            {
                forwardBackwardtilt = Mathf.Abs(forwardBackwardtilt - 360);
                //move something using forwardbackwardtilt as speed
            }
            else if (forwardBackwardtilt > 5 && forwardBackwardtilt < 74)
            {
                //do smth
            }

            sideToSideTilt = topOfJoystick.rotation.eulerAngles.z;
        Debug.Log("this is sidetoside " + forwardBackwardtilt);

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
    public void ApplyLocalPositionToVisuals(WheelCollider collider, Transform Trans)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {

        //float motor = maxMotorTorque * Input.GetAxis("Vertical");
        //float motor = maxMotorTorque * (forwardBackwardtilt/200);
        float motor = 0;
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel, leftWheelTR);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel, rightWheelTR);
        }
    }
    
    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;  
    }
}