using System;
using UnityEngine;
using Weapons;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private Weapon_SO porjectileData;
    private Rigidbody rb;
    private Vector3 velocity;
    private Vector3 acceleration = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = transform.GetChild(0).GetComponent<Rigidbody>();
        velocity = Vector3.forward * porjectileData.initalVelocity;
        acceleration = transform.forward * porjectileData.acceleration;
    }

    private void FixedUpdate()
    {
        
        ManageMovement();
        ManageTracking();
        ManageRendering();
    }

    void ManageMovement()
    {
        //Apply gravity
        acceleration +=  Physics.gravity * Time.fixedDeltaTime; 
        
        //Accelerate acceleration
        acceleration += transform.forward * porjectileData.acceleration * Time.fixedDeltaTime;
        acceleration = Vector3.ClampMagnitude( acceleration, porjectileData.maxAcceleration);
        
        //Apply acceleration
        velocity += acceleration * Time.fixedDeltaTime;
        
        // Clamp velocity
        velocity = Vector3.ClampMagnitude( velocity, porjectileData.maxVelocity);
        rb.velocity = velocity;
    }

    void ManageTracking(Transform target = null)
    {
        if (!porjectileData.canTrack)
            return;
        
        // If the projectile can track, rotate towards the target
        if (target != null)
        {
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, porjectileData.turnRate * Time.fixedDeltaTime);
        }
    }

    void ManageRendering()
    {
        
    }
}
