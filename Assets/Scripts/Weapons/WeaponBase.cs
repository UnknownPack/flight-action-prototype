using System;
using UnityEngine;
using Weapons;

public abstract class WeaponBase : MonoBehaviour
{
    protected Weapon_SO projectileData;
    protected GameObject projectilePrefab;
    protected Transform originTransform;
    
    public virtual void Init(Weapon_SO projectileData, GameObject projectilePrefab, Transform originTransform)
    {
        this.projectileData = projectileData;
        this.projectilePrefab = projectilePrefab;
        this.originTransform = originTransform;
    }
    
    public virtual void Fire()
    {
        
    }
    
    public virtual void Reload()
    {
        
    }
    
    public virtual void ManageAmmo()
    {
        
    }

    public virtual void Update()
    {
         
    }
    
}
