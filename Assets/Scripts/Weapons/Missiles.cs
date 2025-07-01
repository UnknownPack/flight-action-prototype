using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Weapons
{
    public class Missiles : WeaponBase
    {
        private Transform Target()
        {
            
        }
        
        
        private Transform[] hardPoints;
        private bool[] hasMissilesOnHardPoint = { true, true, true, true };

        public void Init(Weapon_SO projectileData, GameObject projectilePrefab, Transform[] hardPoints)
        {
            this.projectileData = projectileData;
            this.projectilePrefab = projectilePrefab;
            this.hardPoints = hardPoints;
        }
        
        public override void Fire()
        {
            GameObject missile = Instantiate(projectilePrefab, originTransform);
            Vector3 force = missile.transform.forward * projectileData.initalVelocity;
            missile.transform.GetChild(0).GetComponent<Rigidbody>()?.AddForce(force, ForceMode.Impulse);
            missile.transform.GetChild(0).GetComponent<Damage>()?.SetStats(originTransform.position, projectileData);
            missile.GetComponent<MissileTracking>().SetTarget();
        }

        public override bool CanFire()
        {
            for (int i = 0; i < hasMissilesOnHardPoint.Length; i++)
            {
                if (!hasMissilesOnHardPoint[i])
                    return false;
            }
            return true;
        }

        public override IEnumerator Reload()
        {
            while (true)
            {
                int i;
                for (i= 0; i < hasMissilesOnHardPoint.Length; i++)
                {
                    if (!hasMissilesOnHardPoint[i])
                    {
                        yield return new WaitForSeconds(projectileData.reloadTime);
                        hasMissilesOnHardPoint[i] = true;
                    }
                }
                i = 0;
            } 
        }
        
    }
}
