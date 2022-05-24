using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.InputSystem;


   
  


public class WheelchairController : MonoBehaviour
{
    //private XRController controller = null;





    
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

       
    }

   private void FixedUpdate()
    {
      

        CurrentAcceleration = Acceleration * Input.GetAxis("Vertical");
        

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

    

}
