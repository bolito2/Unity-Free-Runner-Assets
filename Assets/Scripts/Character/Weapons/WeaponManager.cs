using UnityEngine;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {

    public static WeaponManager instance;

    void Awake()
    {
        instance = this;
    }

    public List<Weapon> Weapons = new List<Weapon>();

    public static Weapon SelectWeapon(int weaponId)
    {
        return instance.Weapons[weaponId];
    }

}
