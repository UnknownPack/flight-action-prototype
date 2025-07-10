using UnityEngine;

[CreateAssetMenu(fileName = "EntityStats", menuName = "Scriptable Objects/EntityStats")]
public class EntityStats : ScriptableObject
{
    public float entityHealth;
    public float entitySpeed;
    public float rotationSpeed;
    public float detectionRange;
}

