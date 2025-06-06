using UnityEngine;

public class planMovement : MonoBehaviour
{
    public float acceleration = 15f;
    public float deceleration = 7.5f;
    public float rotationSpeed = 0.0000005f;
    public float maxSpeed = 1000f;
    public float maxAngleChange = 15f;
    public ControlSurfaces controlSurface;
    
    private float currentSpeed = 0f;
    private Quaternion rotation;
    
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotation = transform.rotation;
    }
    
    void Update()
    {
        // Rotation (pitch, yaw, roll)
        float pitch = 0f;
        float yaw = 0f;
        float roll = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            pitch = 1f;
            RotatePivot(controlSurface.ElevatorRight, pitch);
            RotatePivot(controlSurface.ElevatorLeft, -pitch);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            pitch = -1f;
            RotatePivot(controlSurface.ElevatorRight, -pitch);
            RotatePivot(controlSurface.ElevatorLeft, pitch);
        }

        if (Input.GetKey(KeyCode.A))
            roll = 1f;
        if (Input.GetKey(KeyCode.D))
            roll = -1f;
        RotatePivot(controlSurface.AileronRight, roll);
        RotatePivot(controlSurface.AileronLeft, roll);

        if (Input.GetKey(KeyCode.Q))
            yaw = -1f;
        if (Input.GetKey(KeyCode.E))
            yaw = 1f;
        RotatePivot(controlSurface.Rudder, yaw);

        // Apply rotation relative to the plane
        transform.Rotate(pitch * rotationSpeed * Time.deltaTime, 
            yaw * rotationSpeed * Time.deltaTime,
            roll * rotationSpeed * Time.deltaTime, 
            Space.Self);

        // Speed control
        if (Input.GetKey(KeyCode.LeftShift))
            currentSpeed += acceleration * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftControl))
            currentSpeed -= deceleration * Time.deltaTime;

        currentSpeed = Mathf.Clamp(currentSpeed, -100, maxSpeed);

        // Apply movement
        rb.AddForce(transform.forward * currentSpeed, ForceMode.Acceleration);

        // Debug
        Debug.Log($"Position: {transform.position}, Speed: {currentSpeed}, Rotation: {transform.rotation.eulerAngles}");
    }

    private void RotatePivot(GameObject obj, float direction)
    {
        // Calculate how much we want to rotate this frame.
        // direction is usually -1, 0, or 1 depending on input.
        // maxAngleChange represents how many degrees per second we allow the surface to rotate.
        // Time.deltaTime makes this change frame-rate independent.
        float angleDelta = direction * maxAngleChange * Time.deltaTime;

        // Get the current local X-axis rotation in degrees (range is 0–360).
        float currentAngle = obj.transform.localEulerAngles.x;

        // Convert 0–360 range to -180 to 180 so we can clamp around 0 (neutral position).
        // Example: 350 degrees becomes -10 (slightly up instead of "almost full circle").
        if (currentAngle > 180f) 
            currentAngle -= 360f;

        // Add the desired delta to the current angle.
        // Clamp the result to avoid rotating beyond ±maxAngleChange degrees.
        float targetAngle = Mathf.Clamp(currentAngle + angleDelta, -maxAngleChange, maxAngleChange);

        // Create a new Euler angle vector using the clamped X rotation.
        // Keep the Y and Z rotations as they were.
        Vector3 newRotation = obj.transform.localEulerAngles;
        newRotation.x = targetAngle;

        // Apply the final rotation back to the object (in local space).
        obj.transform.localEulerAngles = newRotation;
    }

}

[System.Serializable]
public struct ControlSurfaces
{
    [SerializeField] private GameObject aileronRight;
    [SerializeField] private GameObject aileronLeft;
    [SerializeField] private GameObject elevatorRight;
    [SerializeField] private GameObject elevatorLeft;
    [SerializeField] private GameObject rudder;

    public GameObject AileronRight => aileronRight;
    public GameObject AileronLeft => aileronLeft;
    public GameObject ElevatorRight => elevatorRight;
    public GameObject ElevatorLeft => elevatorLeft;
    public GameObject Rudder => rudder;
}

