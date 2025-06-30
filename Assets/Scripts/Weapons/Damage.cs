using System;
using Unity.VisualScripting;
using UnityEngine;
using Weapons;

public class Damage : MonoBehaviour
{
    private Vector3 origin, force;
    private Weapon_SO _weaponInformation;
    private Rigidbody _rigidbody;
    private float distance;

    public void SetStats(Vector3 origin, Weapon_SO _weaponInformation)
    {
        this.origin = origin;
        this._weaponInformation = _weaponInformation;
    }
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.magnitude < _weaponInformation.maxVelocity)
        {
            _rigidbody.velocity += _rigidbody.velocity.normalized * _weaponInformation.acceleration * Time.fixedDeltaTime;
            _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, _weaponInformation.maxVelocity);
        }
    }

    private void Update()
    {
        distance = Vector3.Distance(origin, transform.position);
        if (distance >= _weaponInformation.maxRenderDistance)
        {
            // manage object rendering 
        }

        if (distance >= _weaponInformation.maxRange)
        {
            ManageDestruction();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("CanTakeDamage"))
        {
            //TODO: Implement damaging logic here
            
            //TODO: Implement proper destruction lgoc (consider pooling etc...)
            ManageDestruction();
        }
    }

    private void ManageDestruction()
    {
        
    }

    private void ManageRendering()
    {
        
    }
}
