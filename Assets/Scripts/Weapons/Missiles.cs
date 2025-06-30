using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Weapons
{
    public class Missiles : WeaponBase
    {
        private Weapon_SO missileData;
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
            
        }

        public override bool CanFire()
        {
            
        }

        public virtual IEnumerator Reload()
        {
            
        }
        
    }
}
