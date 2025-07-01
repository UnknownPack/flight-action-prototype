using System;
using UnityEngine;

public class MissileTracking : MonoBehaviour
{
    private Transform target;
    private bool hasTarget = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetTarget(Transform target)
    {
        this.target = target;
        hasTarget = true;
    }
    
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(hasTarget)
            TrackTarget();
    }

    void TrackTarget()
    {
        //TODO: Implement tracking logic
    }
}
