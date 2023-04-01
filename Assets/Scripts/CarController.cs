using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static CarController;

public class CarController : MonoBehaviour
{
    [System.Serializable]
    public class Wheel
    {
        public WheelCollider collider;
    }

    [System.Serializable]
    public class Axle
    {
        public Wheel leftWheel;
        public Wheel rightWheel;
        public bool isMotor;
        public bool isSteering;
    }

    [SerializeField] Axle[] axles;
    [SerializeField] float maxMotorTorque;
    [SerializeField] float maxSteeringAngle;

    public void FixedUpdate()
    {
        float motor = 0; 
        // motor = < motor torque* input axis "Vertical" >
        float steering = 0; 
        // steering = <max steering angle* input axis "Horizontal" >

    foreach (Axle axle in axles)
        {
            if (axle.isSteering)
            {
                axle.leftWheel.collider.steerAngle = steering;
                // <set right wheel steer angle >
            }
            if (axle.isMotor)
            {
                axle.leftWheel.collider.motorTorque = motor;
                // <set right wheel motor torque >
            }
        }
    }
}