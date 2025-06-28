using UnityEngine;
using Weapons;
using Weapons.Weapons;

public class Arsenal_Manager : MonoBehaviour
{
    [Header("Weapon Data")]
    [SerializeField] private Weapon_SO cannonBulletData;
    [SerializeField] private Weapon_SO missileData;
    
    [Header("Weapon Prefabs")]
    [SerializeField] private GameObject cannonBulletPrefab;
    [SerializeField] private GameObject missilePrefab;
    
    private planMovement planeMovement;
    private HardPoints hardPoints;
    private Cannon cannon;
    private Missiles missile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        planeMovement = GetComponent<planMovement>();
        hardPoints = planeMovement.hardPoints;
        cannon = gameObject.AddComponent<Cannon>();
        missile = gameObject.AddComponent<Missiles>();
        cannon.Init(cannonBulletData, cannonBulletPrefab, hardPoints.MainGun.transform);
        missile.Init(cannonBulletData, cannonBulletPrefab, hardPoints.GetAllHardPoints());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
