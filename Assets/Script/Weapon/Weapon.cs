using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int damage = 100;
    public int ammo = 30;
    public float accuracy = 1f;
    public float range = 10f;
    public float rateOfFire = 5f;
    public GameObject projectile;
    protected int currentAmmo = 0;
    public Transform spawnPoint;
    /* Task 1     create a draw.io for the projectile system
     * Details: projectile system needs the following structure
     *                     Projectile
     *                     /    |    \              
     *                  Normal  Fire  Explosive
     * Variables for each class
     * Functions for each class
     * 
     * 
     * Task 2). Player cannot shoot until the weapon is ready to fire
     */

    public abstract void Attack();

    public void Reload()
    {
        // Reset currentAmmo;
        currentAmmo = ammo;
    }
}
