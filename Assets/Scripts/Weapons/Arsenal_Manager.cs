using System.Collections.Generic;
using Unity.VisualScripting;
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

    private WeaponBase currentWeapon;
    private Dictionary<WeaponBase, float> ammo = new Dictionary<WeaponBase, float>();
    
    private planMovement planeMovement;
    private HardPoints hardPoints;
    private Cannon cannon;
    private Missiles missile;

    private bool switchWeapon = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        planeMovement = GetComponent<planMovement>();
        hardPoints = planeMovement.hardPoints;
        cannon = gameObject.AddComponent<Cannon>();
        missile = gameObject.AddComponent<Missiles>();
        cannon.Init(cannonBulletData, cannonBulletPrefab, hardPoints.MainGun.transform);
        missile.Init(missileData, missilePrefab, hardPoints.GetAllHardPoints());
        ammo.Add(cannon, cannonBulletData.amountOfAmmo);
        ammo.Add(missile, missileData.amountOfAmmo);

        currentWeapon = cannon;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            // true = cannon, false = missiles
            switchWeapon = !switchWeapon;

        currentWeapon = switchWeapon ? cannon : missile;

        bool inputType = switchWeapon ? Input.GetKey(KeyCode.Space) : Input.GetKeyDown(KeyCode.Space);
        if(inputType && currentWeapon.CanFire() && ammo[currentWeapon] > 0)
            currentWeapon.Fire();

    }
}
