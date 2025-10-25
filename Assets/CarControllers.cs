using UnityEngine;

public class CarControllers : MonoBehaviour
{
    [SerializeField] private WheelCollider FrontLeftWheelCollider;
     [SerializeField] private WheelCollider FrontRightWheelCollider;
     [SerializeField] private WheelCollider RearLeftWheelCollider;
     [SerializeField] private WheelCollider RearRightWheelCollider;

     [SerializeField] private Transform FrontLeftWheelTransform;
     [SerializeField] private Transform FrontRightWheelTransform;
     [SerializeField] private Transform RearLeftWheelTransform;
     [SerializeField] private Transform RearRightWheelTransform;
     [SerializeField] private Transform CarCenterOfMassTransform;
     
     [SerializeField] private float motorForce = 100f;
     [SerializeField] private float steerAngle = 30f;
     [SerializeField] private float brakeForce = 1000f;
    private float verticalInput;
    private Rigidbody rigidbody;
    private float horizontalInput;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = CarCenterOfMassTransform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MotorForce();
        updateWheels();
        GetInput();
        steering();
        ApplyBrakes();
    }
    void GetInput()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }
    void ApplyBrakes()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            FrontLeftWheelCollider.brakeTorque = brakeForce;
            FrontRightWheelCollider.brakeTorque = brakeForce;
            RearLeftWheelCollider.brakeTorque = brakeForce;
            RearRightWheelCollider.brakeTorque = brakeForce;
        }
        else
        {
            FrontLeftWheelCollider.brakeTorque = 0f;
            FrontRightWheelCollider.brakeTorque = 0f;
            RearLeftWheelCollider.brakeTorque = 0f;
            RearRightWheelCollider.brakeTorque = 0f;
        }
        }

    void MotorForce()
    {
        FrontLeftWheelCollider.motorTorque = motorForce * verticalInput;
        FrontRightWheelCollider.motorTorque = motorForce * verticalInput;
    }
    void steering()
    {
        FrontLeftWheelCollider.steerAngle = steerAngle * horizontalInput ;
        FrontRightWheelCollider.steerAngle = steerAngle * horizontalInput;
    }
    void updateWheels()
    {
        RotateWheel(FrontLeftWheelCollider, FrontLeftWheelTransform);
        RotateWheel(FrontRightWheelCollider, FrontRightWheelTransform);
        RotateWheel(RearLeftWheelCollider, RearLeftWheelTransform);
        RotateWheel(RearRightWheelCollider,RearRightWheelTransform);
    }
    void RotateWheel(WheelCollider wheelCollider,Transform transform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        transform.position = pos;
        transform.rotation = rot;
    }
}
