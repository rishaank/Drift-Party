using UnityEngine;
using UnityEngine.SceneManagement;

namespace WaterSystem
{
    public class Car_controller : MonoBehaviour
    {
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";

        private float HorizontalInput;
        private float VerticalInput;
        private float currentsteerAngle;

        public float mass = -0.9f;
        public float intensity = 2.5f;
        public float carSpeed;

        public Rigidbody rb;

        public static Car_controller cc;

        private Vector3 currentposition;

        public GameObject P3;

        [SerializeField] private Light left_tailight;
        [SerializeField] private Light right_tailight;

        [SerializeField] private float motorForce;
        [SerializeField] private float maxSteerAngle;

        [SerializeField] private WheelCollider frontLeftWheelCollider;
        [SerializeField] private WheelCollider frontRightWheelCollider;
        [SerializeField] private WheelCollider rearLeftWheelCollider;
        [SerializeField] private WheelCollider rearRightWheelCollider;

        [SerializeField] private Transform frontLeftWheelTransform;
        [SerializeField] private Transform frontRightWheelTransform;
        [SerializeField] private Transform rearLeftWheelTransform;
        [SerializeField] private Transform rearRightWheelTransform;

        private void Update()
        {
            GetInput();
            HandleMotor();
            HandleSteering();
            UpdateWheels();
        }

        private void GetInput()
        {
            HorizontalInput = Input.GetAxis(HORIZONTAL);
            VerticalInput = Input.GetAxis(VERTICAL);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                left_tailight.intensity = 0f;
                right_tailight.intensity = 0f;
            }
            if (Input.GetKey(KeyCode.W))
            {
                left_tailight.intensity = 0f;
                right_tailight.intensity = 0f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                left_tailight.intensity = intensity;
                right_tailight.intensity = intensity;
            }
            if (Input.GetKey(KeyCode.S))
            {
                left_tailight.intensity = intensity;
                right_tailight.intensity = intensity;
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKey(KeyCode.Alpha1))
            {
                SceneManager.LoadScene(1);
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                SceneManager.LoadScene(2);
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                SceneManager.LoadScene(3);
            }
        }

        private void HandleMotor()
        {
            frontLeftWheelCollider.motorTorque = VerticalInput * motorForce;
            frontRightWheelCollider.motorTorque = VerticalInput * motorForce;
            rearLeftWheelCollider.motorTorque = VerticalInput * motorForce / 4;
            rearRightWheelCollider.motorTorque = VerticalInput * motorForce / 4;
            carSpeed = rb.velocity.magnitude * 3.6f;
        }

        private void HandleSteering()
        {
            currentsteerAngle = maxSteerAngle * HorizontalInput;
            frontLeftWheelCollider.steerAngle = currentsteerAngle;
            frontRightWheelCollider.steerAngle = currentsteerAngle;
        }

        private void UpdateWheels()
        {
            UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
            UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
            UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
            UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        }

        private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
        {
            Vector3 pos;
            Quaternion rot;
            wheelCollider.GetWorldPose(out pos, out rot);
            wheelTransform.rotation = rot;
        }

        void Start()
        {
            cc = this;
            rb = GetComponent<Rigidbody>();
            GetComponent<Rigidbody>().centerOfMass = new Vector3(0f, mass, 0f);
        }
    }
}
