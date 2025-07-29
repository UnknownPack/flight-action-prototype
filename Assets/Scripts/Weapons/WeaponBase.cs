using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using Weapons;

public abstract class WeaponBase : MonoBehaviour
{
    protected Weapon_SO projectileData;
    protected GameObject projectilePrefab;
    protected GameObject originTransform;
    protected bool canFire = true;
    
    public virtual void Init(Weapon_SO projectileData, GameObject projectilePrefab,GameObject originTransform)
    {
        this.projectileData = projectileData;
        this.projectilePrefab = projectilePrefab;
        this.originTransform = originTransform;
    }
    
    public virtual void Fire()
    {
        Vector3 spawnTransform = originTransform.transform.position;
        GameObject bullet = Instantiate(projectilePrefab, spawnTransform, originTransform.transform.localRotation);
            Debug.Log($"origin: {gameObject.transform.position} \n spawn location: {spawnTransform}");
        Vector3 force = bullet.transform.forward * projectileData.initalVelocity;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(force, ForceMode.Impulse);
        bullet.transform.GetChild(0).GetComponent<Damage>().SetStats(spawnTransform, projectileData, rb);
        canFire = false;
        StartCoroutine(Reload(projectileData.reloadTime));
    }

    public virtual bool CanFire()
    {
        return canFire;
    }

    public virtual IEnumerator Reload(float reloadTime)
    {
        yield return new WaitForSeconds(reloadTime);
        canFire = true;
    }
    
    public virtual void ManageAmmo()
    {
        
    }

    public virtual void Update()
    {
         
    }
    
}
