using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

    public int WeaponToSelect;
    public Weapon selectedWeapon;
    public GameObject bulletPrefab;
    public Transform Arm;
    public Transform ShootPoint;
    float t;

    public int actualBullets, actualClipBullets;

    public bool isReloaded = true;

    void Start()
    {
        selectedWeapon = WeaponManager.SelectWeapon(WeaponToSelect);
    }

    void FixedUpdate()
    {
        t -= Time.deltaTime;
    }

    public void Shoot()
    {
        if (t <= 0)
        {
            t = selectedWeapon.basic.timeBetweenBullets;
            if (isReloaded && (selectedWeapon.advanced.maxBullets == 0 || actualBullets > 0) && (selectedWeapon.advanced.bulletsPerClip == 0 || actualClipBullets > 0))
            {
                if (selectedWeapon.advanced.bulletsPerShoot > 0)
                {
                    for (int i = 0; i < selectedWeapon.advanced.bulletsPerShoot; i++)
                    {
                        if (Arm != null)
                        {

                            if (ShootPoint != null)
                            {

                                GameObject bullet = Instantiate(bulletPrefab, ShootPoint.position, Arm.rotation) as GameObject;
                                Bullet bulletScript = bullet.GetComponent<Bullet>();
                                if (selectedWeapon.advanced.bulletSpeed != 0)
                                    bulletScript.bulletSpeed = selectedWeapon.advanced.bulletSpeed;
                            }
                            else
                            {
                                GameObject bullet = Instantiate(bulletPrefab, Arm.position, Arm.rotation) as GameObject;
                                Bullet bulletScript = bullet.GetComponent<Bullet>();
                                if (selectedWeapon.advanced.bulletSpeed != 0)
                                    bulletScript.bulletSpeed = selectedWeapon.advanced.bulletSpeed;
                            }    
                        }
                        else
                        {
                            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
                            Bullet bulletScript = bullet.GetComponent<Bullet>();

                            if (selectedWeapon.advanced.bulletSpeed != 0)
                                bulletScript.bulletSpeed = selectedWeapon.advanced.bulletSpeed;
                        }
                    }
                }
                else
                {
                    if (Arm != null)
                    {
                        if (ShootPoint != null)
                        {

                            GameObject bullet = Instantiate(bulletPrefab, ShootPoint.position, Arm.rotation) as GameObject;
                            Bullet bulletScript = bullet.GetComponent<Bullet>();
                            if (selectedWeapon.advanced.bulletSpeed != 0)
                                bulletScript.bulletSpeed = selectedWeapon.advanced.bulletSpeed;
                        }
                        else
                        {
                            GameObject bullet = Instantiate(bulletPrefab, Arm.position, Arm.rotation) as GameObject;
                            Bullet bulletScript = bullet.GetComponent<Bullet>();
                            if (selectedWeapon.advanced.bulletSpeed != 0)
                                bulletScript.bulletSpeed = selectedWeapon.advanced.bulletSpeed;
                        }
                    }
                    else
                    {
                        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
                        Bullet bulletScript = bullet.GetComponent<Bullet>();

                        if (selectedWeapon.advanced.bulletSpeed != 0)
                            bulletScript.bulletSpeed = selectedWeapon.advanced.bulletSpeed;
                    }
                }
            }
        }
    }
}
