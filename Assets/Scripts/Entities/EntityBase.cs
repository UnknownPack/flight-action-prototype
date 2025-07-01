using System;
using UnityEngine;

namespace Entities
{
    public abstract class EntityBase : MonoBehaviour
    {
        protected EntityStats.EntityStats _healthStats;

        private void Start()
        {
            
        }

        private void Update()
        {
            
        }
    }
}

namespace EntityStats
{
    [CreateAssetMenu(fileName = "EntityStats", menuName = "Scriptable Objects/Enemy Stats")]
    public class EntityStats : ScriptableObject
    {
        public float entityHealth;
        public float entitySpeed;
        public float rotationSpeed;
        public float detectionRange;
        
    }
}

