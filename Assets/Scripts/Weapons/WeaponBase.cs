using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using Weapons;

public abstract class WeaponBase : MonoBehaviour
{
    protected Weapon_SO projectileData;
    protected GameObject projectilePrefab;
    protected Transform originTransform;
    protected bool canFire = true;
    
    public virtual void Init(Weapon_SO projectileData, GameObject projectilePrefab, Transform originTransform)
    {
        this.projectileData = projectileData;
        this.projectilePrefab = projectilePrefab;
        this.originTransform = originTransform;
    }
    
    public virtual void Fire()
    {
        GameObject bullet = Instantiate(projectilePrefab, originTransform);
        Vector3 force = bullet.transform.forward * projectileData.initalVelocity;
        bullet.GetComponent<Rigidbody>()?.AddForce(force, ForceMode.Impulse);
        bullet.GetComponent<Damage>()?.SetStats(originTransform.position, projectileData);
    }

    public virtual bool CanFire()
    {
        return true;
    }

    public virtual IEnumerator Reload()
    {
        yield return null;
    }
    
    public virtual void ManageAmmo()
    {
        
    }

    public virtual void Update()
    {
         
    }
    
}
