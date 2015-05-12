using UnityEngine;
using System.Collections;

[System.Serializable]
public class Weapon{
    [System.Serializable]
    public class Basic
    {
        public string name;
        public float timeBetweenBullets;
        public float damage;
    }


    public Basic basic;
    public Advanced advanced;


    [System.Serializable]
    public class Advanced
    {
        public float bulletScatter;
        public int bulletsPerShoot;
        public int bulletsPerClip;
        public int maxBullets;
        public float reloadTime;
        public float bulletSpeed;
    }

    public Weapon(string name, float timeBetweenBullets, float damage)
    {
        basic.name = name;
        basic.timeBetweenBullets = timeBetweenBullets;
        basic.damage = damage;
    }

    public Weapon(string name, float timeBetweenBullets, float damage, float bulletScatter, int bulletsPerShoot, int bulletsPerClip, int maxBullets, float reloadTime, float bulletSpeed)
    {
        basic.name = name;
        basic.timeBetweenBullets = timeBetweenBullets;
        basic.damage = damage;

        advanced.bulletScatter = bulletScatter;
        advanced.bulletsPerShoot = bulletsPerShoot;
        advanced.bulletsPerClip = bulletsPerClip;
        advanced.maxBullets = maxBullets;
        advanced.reloadTime = reloadTime;
        advanced.bulletSpeed = bulletSpeed;
    }
}
