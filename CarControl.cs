using UnityEngine;

public class CarControl : MonoBehaviour
{
    #region --- helper --
    [System.Serializable]
    public struct WheelInfo
    {
        public Transform visualwheel;
        public WheelCollider colliderwheel;
    }
    #endregion

    public float motor = 800;
    public float steer = 50;
    public float brake = 440;
    public WheelInfo FL;
    public WheelInfo FR;
    public WheelInfo BL;
    public WheelInfo BR;

    private void FixedUpdate()
    {
        //movement and steering
        float vert = Input.GetAxis("Vertical");     // -1..0..1
        float horz = Input.GetAxis("Horizontal");
        
        FL.colliderwheel.steerAngle = horz * steer;
        FR.colliderwheel.steerAngle = horz * steer;
        BL.colliderwheel.motorTorque = vert * motor;
        BR.colliderwheel.motorTorque = vert * motor;

        //brakes
        if (Input.GetButton("Fire1") == true)   //leftctrl, gamepad A
        {
            FL.colliderwheel.brakeTorque = brake;
            FR.colliderwheel.brakeTorque = brake;
            BL.colliderwheel.brakeTorque = brake;
            BR.colliderwheel.brakeTorque = brake;
        }
        else
        {
            FL.colliderwheel.brakeTorque = 0;
            FR.colliderwheel.brakeTorque = 0;
            BL.colliderwheel.brakeTorque = 0;
            BR.colliderwheel.brakeTorque = 0;
        }

        //update visual wheel
        Vector3 pos;
        Quaternion rot;
        FL.colliderwheel.GetWorldPose(out pos, out rot);
        FL.visualwheel.position = pos;
        FL.visualwheel.rotation = rot;
        FR.colliderwheel.GetWorldPose(out pos, out rot);
        FR.visualwheel.position = pos;
        FR.visualwheel.rotation = rot;
        BL.colliderwheel.GetWorldPose(out pos, out rot);
        BL.visualwheel.position = pos;
        BL.visualwheel.rotation = rot;
        BR.colliderwheel.GetWorldPose(out pos, out rot);
        BR.visualwheel.position = pos;
        BR.visualwheel.rotation = rot;
    }
}
