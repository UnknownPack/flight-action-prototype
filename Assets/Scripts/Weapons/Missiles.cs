using Unity.VisualScripting;
using UnityEngine;

namespace Weapons
{
    public class Missiles : WeaponBase
    {
        private Weapon_SO missileData;
        private Transform[] hardPoints;

        public void Init(Weapon_SO projectileData, GameObject projectilePrefab, Transform[] hardPoints)
        {
            this.projectileData = projectileData;
            this.projectilePrefab = projectilePrefab;
            this.hardPoints = hardPoints;
        }
        
        public void Fire(GameObject projectile, Transform origin, Vector3 targetPosition)
        {
            
        }

        public void Reload(GameObject projectile)
        {
            
        }
        
    }
}
