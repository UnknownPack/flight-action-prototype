using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "Weapon_SO", menuName = "Scriptable Objects/Weapon_SO")]
    public class Weapon_SO : ScriptableObject
    {
        public float initalVelocity;
        public float maxVelocity;  
        public float acceleration;
        public float maxAcceleration;
        public float maxRange;
        public float maxRenderDistance;

        public bool canTrack;
        public float turnRate;
        public float damage;
        
        public float reloadTime;
        public float amountOfAmmo;
    }
}


