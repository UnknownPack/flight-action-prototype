using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Weapons
{
    public class Missiles : WeaponBase
    {
        private Transform Target;
        
        private GameObject[] hardPoints;
        private bool[] hasMissilesOnHardPoint;
        private GameObject[] missiles;

        public void Init(Weapon_SO projectileData, GameObject projectilePrefab, GameObject[] hardPoints)
        {
            this.projectileData = projectileData;
            this.projectilePrefab = projectilePrefab;
            this.hardPoints = hardPoints;
            
            hasMissilesOnHardPoint = new bool[hardPoints.Length];
            missiles = new GameObject[hardPoints.Length];
            for (int i = 0; i < hardPoints.Length; i++)
            {
                hasMissilesOnHardPoint[i] = true;
                missiles[i] = Instantiate(projectilePrefab, hardPoints[i].transform.position, hardPoints[i].transform.rotation);
            }
        }
        
        public override void Fire()
        {
            GameObject activatedMissile = GetAnyMissileArmedOnHardPoint();
            if (activatedMissile == null)
            {
                Debug.LogWarning("No missiles available to fire.");
                return;
            }
            Vector3 force = activatedMissile.transform.forward * projectileData.initalVelocity;
            Rigidbody rb = activatedMissile.GetComponent<Rigidbody>();
            rb.AddForce(force, ForceMode.Impulse);
            Damage damage = activatedMissile.GetComponent<Damage>();
            if (damage != null)
            {
                damage.SetStats(activatedMissile.transform.position, projectileData, rb);
                damage.SetActive(true);  
            } 
            activatedMissile.GetComponent<MissileTracking>().SetTarget(Target);
        }

        public override bool CanFire()
        {
            return CheckHardPointsLoaded(true);
        }

        public bool CheckHardPointsLoaded(bool check)
        {
            for (int i = 0; i < hasMissilesOnHardPoint.Length; i++)
            {
                if (hasMissilesOnHardPoint[i] == check)
                    return true;
            }
            return false;
        }

        public override IEnumerator Reload(float reloadTime)
        {
            while (CheckHardPointsLoaded(false))
            {
                int i;
                for (i= 0; i < hasMissilesOnHardPoint.Length; i++)
                {
                    if (!hasMissilesOnHardPoint[i])
                    {
                        yield return new WaitForSeconds(reloadTime);
                        hasMissilesOnHardPoint[i] = true;
                        missiles[i] = Instantiate(projectilePrefab, hardPoints[i].transform.position, hardPoints[i].transform.rotation);
                    }
                }
                i = 0;
            } 
        }
        
        private GameObject GetAnyMissileArmedOnHardPoint()
        {
            for (int i = 0; i < hardPoints.Length; i++)
            {
                if(hasMissilesOnHardPoint[i])
                {
                    hasMissilesOnHardPoint[i] = false;
                    return missiles[i];
                }
            }
            return null;
        }
        
    }
}
