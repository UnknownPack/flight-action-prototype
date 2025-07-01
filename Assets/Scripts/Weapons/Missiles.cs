using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Weapons
{
    public class Missiles : WeaponBase
    {
        private Transform Target;
        
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
            GameObject missile = Instantiate(projectilePrefab, originTransform.position, originTransform.rotation);
            Vector3 force = missile.transform.forward * projectileData.initalVelocity;
            Rigidbody rb = missile.GetComponent<Rigidbody>();
            rb.AddForce(force, ForceMode.Impulse);
            missile.transform.GetChild(0).GetComponent<Damage>()?.SetStats(originTransform.position, projectileData, rb);
            missile.GetComponent<MissileTracking>().SetTarget(Target);
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
                    }
                }
                i = 0;
            } 
        }
        
    }
}
