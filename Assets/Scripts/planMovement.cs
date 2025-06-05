using UnityEngine;

public class planMovement : MonoBehaviour
{
    public float acceleration = 15f;
    public float deceleration = 7.5f;
    public float maxSpeed = 1000f;
    public float maxAngleChange = 45f;
    public GameObject aileronRight;
    public GameObject aileronLeft;
    public GameObject elevatorRight;
    public GameObject elevatorLeft;
    public GameObject RudderRight;
    public GameObject RudderLeft;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            
        }
        
        if (Input.GetKey(KeyCode.Q))
        {
            
        }
        
        if (Input.GetKey(KeyCode.E))
        {
            
        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            
        }
        
        if (Input.GetKey(KeyCode.LeftControl))
        {
            
        }
    }
}
